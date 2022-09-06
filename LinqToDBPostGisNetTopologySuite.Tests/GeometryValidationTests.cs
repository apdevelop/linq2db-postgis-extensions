using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries.Geometry;

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
                db.TestGeographies.Delete();
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
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries.Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries.Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => null)
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
            const string Wkt1 = "LINESTRING(0 0, 1 1)";
            const string Wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";

            const string ExpectedGeomType = "Point";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.Connection.RegisterPostGisCompositeTypes();
                // or PostGisCompositeTypeMapper.RegisterPostGisCompositeTypesGlobally();

                var expectedReason = base.CurrentVersion >= base.Version320
                    ? "Ring Self-intersection"
                    : "Self-intersection";

                var actual1 =
                    db.Select(() => GeometryValidation.STIsValidDetail(GeometryInput.STGeometryFromText(Wkt1)));
                var actual2 =
                    db.Select(() => GeometryValidation.STIsValidDetail(GeometryInput.STGeometryFromText(Wkt2)));
                var actual3 = db.Select(() => GeometryValidation.STIsValidDetail((NTSG)null));

                Assert.IsTrue(actual1.IsValid);
                Assert.IsNull(actual1.Reason);
                Assert.IsNull(actual1.Location);

                Assert.IsFalse(actual2.IsValid);
                Assert.AreEqual(expectedReason, actual2.Reason);
                Assert.AreEqual(ExpectedGeomType, actual2.Location.GeometryType);

                Assert.IsNull(actual3);
            }
        }

        [Test]
        public void TestSTIsValidReason()
        {
            const string Wkt1 = "LINESTRING(0 0, 1 1)";
            const string Wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";

            const string ExpectedValidGeom = "Valid Geometry";
            const string ExpectedWithFlag = "Self-intersection";

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                var expectedDefault = base.CurrentVersion >= base.Version320
                    ? "Ring Self-intersection[1 1]"
                    : "Self-intersection[0 0]";

                var actual1V1 = db.Select(() => GeometryInput.STGeomFromText(Wkt1).STIsValidReason());
                var actual1V2 = db.Select(() => GeometryValidation.STIsValidReason(Wkt1));
                var actual1V3 = db.Select(() => GeometryValidation.STIsValidReason(Wkt1, 1));

                var actual2V1 = db.Select(() => GeometryInput.STGeomFromText(Wkt2).STIsValidReason());
                var actual2V2 = db.Select(() => GeometryValidation.STIsValidReason(Wkt2));
                var actual2V3 = db.Select(() => GeometryValidation.STIsValidReason(Wkt2, 1));

                var actual3 = db.Select(() => ((NTSG)null).STIsValidReason());

                Assert.AreEqual(ExpectedValidGeom, actual1V1);
                Assert.AreEqual(ExpectedValidGeom, actual1V2);
                Assert.AreEqual(ExpectedValidGeom, actual1V3);

                Assert.AreEqual(expectedDefault, actual2V1);
                Assert.AreEqual(expectedDefault, actual2V2);
                Assert.AreEqual(ExpectedWithFlag, actual2V3);

                Assert.IsNull(actual3);
            }
        }

        [Test]
        public void TestSTMakeValid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING(0 0,1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1)).Insert();

                const string Wkt2 = "POLYGON((0 0,1 1,1 2, 1 1,0 0))";
                db.TestGeometries.Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(g => g.Geometry, () => null).Insert();

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
