using System.Linq;

using LinqToDB;

using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryValidationTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Delete();
            }
        }

        [Test]
        public void TestSTIsValid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries.Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries.Value(g => g.Id, 3)
                    .Value(p => p.Geometry, () => null)
                    .Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsValid()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsValid()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsValid()).Single());

                Assert.IsTrue(db.Select(() => GeometryValidation.STIsValid(Wkt1)));
                Assert.IsFalse(db.Select(() => GeometryValidation.STIsValid(Wkt2)));
                Assert.IsNull(db.Select(() => GeometryValidation.STIsValid((string)null)));

                Assert.IsTrue(db.Select(() => GeometryValidation.STIsValid(Wkt1, 1)));
                Assert.IsFalse(db.Select(() => GeometryValidation.STIsValid(Wkt2, 1)));
                Assert.IsNull(db.Select(() => GeometryValidation.STIsValid((string)null, 1)));
            }
        }

        [Test]
        public void TestSTIsValidDetail()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                // TODO: ! utility (extension) method to globally register composite types, 
                // like 'NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite()' or 'conn.TypeMapper.UseNetTopologySuite()'
                (db.Connection as Npgsql.NpgsqlConnection).TypeMapper.MapComposite<ValidDetail>(ValidDetail.CompositeTypeName);

                var d1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STIsValidDetail())
                    .Single();

                Assert.IsTrue(d1.IsValid);
                Assert.IsNull(d1.Reason);
                Assert.IsNull(d1.Location);

                var d2 = db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STIsValidDetail())
                        .Single();

                Assert.IsFalse(d2.IsValid);
                Assert.AreEqual("Self-intersection", d2.Reason);
                Assert.AreEqual("Point", d2.Location.GeometryType);

                Assert.IsNull(
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STIsValidDetail())
                        .Single());

                var d1s = db.Select(() => GeometryValidation.STIsValidDetail(Wkt1));
                Assert.IsTrue(d1s.IsValid);
                Assert.IsNull(d1s.Reason);
                Assert.IsNull(d1s.Location);

                var d2s = db.Select(() => GeometryValidation.STIsValidDetail(Wkt2));
                Assert.IsFalse(d2s.IsValid);
                Assert.AreEqual("Self-intersection", d2s.Reason);
                Assert.AreEqual("Point", d2s.Location.GeometryType);
            }
        }

        [Test]
        public void TestSTIsValidReason()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(
                    "Valid Geometry",
                    db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsValidReason()).Single());

                Assert.AreEqual(
                    "Self-intersection[0 0]",
                    db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsValidReason()).Single());

                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsValidReason()).Single());

                Assert.AreEqual(
                    "Valid Geometry",
                    db.Select(() => GeometryValidation.STIsValidReason(Wkt1)));

                Assert.AreEqual(
                    "Self-intersection[0 0]",
                    db.Select(() => GeometryValidation.STIsValidReason(Wkt2)));

                Assert.AreEqual(
                    "Valid Geometry",
                    db.Select(() => GeometryValidation.STIsValidReason(Wkt1, 1)));

                Assert.AreEqual(
                    "Self-intersection",
                    db.Select(() => GeometryValidation.STIsValidReason(Wkt2, 1)));
            }
        }

        [Test]
        public void TestSTMakeValid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0,1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "POLYGON((0 0,1 1,1 2, 1 1,0 0))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(
                    Wkt1,
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STMakeValid().STAsText())
                        .Single());

                Assert.AreEqual(
                    "MULTILINESTRING((0 0,1 1),(1 1,1 2))",
                    db.TestGeometries
                        .Where(g => g.Id == 2)
                        .Select(g => g.Geometry.STMakeValid().STAsText())
                        .Single());

                Assert.IsNull(
                    db.TestGeometries
                        .Where(g => g.Id == 3)
                        .Select(g => g.Geometry.STMakeValid())
                        .Single());

                Assert.IsNull(db.Select(() => GeometryValidation.STMakeValid((string)null)));

                Assert.AreEqual(
                    Wkt1,
                    db.Select(() => GeometryValidation.STMakeValid(Wkt1).STAsText()));

                Assert.AreEqual(
                    "MULTILINESTRING((0 0,1 1),(1 1,1 2))",
                    db.Select(() => GeometryValidation.STMakeValid(Wkt2).STAsText()));
            }
        }
    }
}
