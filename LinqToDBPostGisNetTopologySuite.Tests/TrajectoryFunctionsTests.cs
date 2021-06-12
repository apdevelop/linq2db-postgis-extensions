using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class TrajectoryFunctionsTests : TestsBase
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
        public void TestSTIsValidTrajectory()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () =>
                         GeometryConstructors.STMakeLine(
                             GeometryConstructors.STMakePointM(0, 0, 1),
                             GeometryConstructors.STMakePointM(0, 1, 2)))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () =>
                         GeometryConstructors.STMakeLine(
                             GeometryConstructors.STMakePointM(0, 0, 1),
                             GeometryConstructors.STMakePointM(0, 1, 0)))
                    .Insert();

                db.TestGeometries.Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.IsTrue(db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STIsValidTrajectory()).Single());

                Assert.IsFalse(db.TestGeometries
                    .Where(g => g.Id == 2)
                    .Select(g => g.Geometry.STIsValidTrajectory())
                    .Single());

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 3)
                    .Select(g => g.Geometry.STIsValidTrajectory())
                    .Single());

                Assert.IsTrue(db.Select(() => TrajectoryFunctions.STIsValidTrajectory("LINESTRING(0 0 0 1,0 1 0 2)")));
                Assert.IsFalse(db.Select(() => TrajectoryFunctions.STIsValidTrajectory("POINT(0 0)")));
            }
        }

        [Test]
        public void TestSTClosestPointOfApproach()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING ZM (0 0 0 1432623600,10 0 5 1432627200)";
                db.TestGeometries
                    .Value(g => g.Id, 1).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "LINESTRING ZM (0 2 10 1432623600,12 1 2 1432627200)";
                db.TestGeometries
                    .Value(g => g.Id, 2).Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3).Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(1432626331.03448,
                    db.TestGeometries
                        .Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STClosestPointOfApproach(db.TestGeometries
                                        .Where(g2 => g2.Id == 2).Single().Geometry))
                        .Single().Value,
                    1.0E-3);

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 3)
                    .Select(g => g.Geometry.STClosestPointOfApproach(null))
                    .Single());

                Assert.AreEqual(
                    1432626331.03448,
                    db.Select(() => TrajectoryFunctions.STClosestPointOfApproach(Wkt1, Wkt2)).Value,
                    1.0E-3);

                Assert.IsNull(db.Select(() => TrajectoryFunctions.STClosestPointOfApproach((string)null, (string)null)));
            }
        }

        [Test]
        public void TestSTDistanceCPA()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING ZM (0 0 0 1432623600,10 0 5 1432627200)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "LINESTRING ZM (0 2 10 1432623600,12 1 2 1432627200)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries
                    .Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.AreEqual(
                    1.96521473776207,
                    db.TestGeometries.Where(g => g.Id == 1)
                        .Select(g => g.Geometry.STDistanceCPA(db.TestGeometries.Where(g2 => g2.Id == 2).Single().Geometry))
                        .Single().Value,
                        1.0E-8);

                Assert.IsNull(db.TestGeometries
                    .Where(g => g.Id == 3)
                    .Select(g => g.Geometry.STDistanceCPA(null))
                    .Single());

                Assert.AreEqual(
                        1.96521473776207,
                        db.Select(() => TrajectoryFunctions.STDistanceCPA(Wkt1, Wkt2)).Value,
                        1.0E-8);

                Assert.IsNull(db.Select(() => TrajectoryFunctions.STDistanceCPA((string)null, (string)null)));
            }
        }

        [Test]
        public void TestSTCPAWithin()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt1 = "LINESTRING ZM (0 0 0 1432623600,10 0 5 1432627200)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt1))
                    .Insert();

                const string Wkt2 = "LINESTRING ZM (0 2 10 1432623600,12 1 2 1432627200)";
                db.TestGeometries
                    .Value(g => g.Id, 2)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt2))
                    .Insert();

                db.TestGeometries.Value(g => g.Id, 3)
                    .Value(g => g.Geometry, () => null)
                    .Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCPAWithin(db.TestGeometries.Where(g2 => g2.Id == 2).Single().Geometry, 2))
                    .Single());

                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STCPAWithin(null, 2)).Single());

                Assert.IsTrue(db.Select(() => TrajectoryFunctions.STCPAWithin(Wkt1, Wkt2, 2)));
                Assert.IsNull(db.Select(() => TrajectoryFunctions.STCPAWithin((string)null, (string)null, 2)));
            }
        }
    }
}
