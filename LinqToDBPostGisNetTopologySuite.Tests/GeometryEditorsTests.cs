using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSG = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryEditorsTests : TestsBase
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
        public void TestSTForce2D()
        {
            const string wkt = "LINESTRING(25 50 1, 100 125 1, 150 190 1)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce2D())
                .Single() as NTSG.LineString;

                Assert.AreEqual(2, result.CoordinateSequence.Dimension);
                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
            }
        }

        [Test]
        public void TestSTForce3D()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce3D())
                .Single() as NTSG.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);

                var nonExistM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;

                Assert.AreEqual(false, Double.IsNaN(existZ));
                Assert.AreEqual(true, Double.IsNaN(nonExistM));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).Z);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).Z);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).Z);
            }
        }

        [Test]
        public void TestSTForce3DZ()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce3DZ())
                .Single() as NTSG.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);
                var nonExistM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;

                Assert.AreEqual(false, Double.IsNaN(existZ));
                Assert.AreEqual(true, Double.IsNaN(nonExistM));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).Z);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).Z);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).Z);
            }
        }

        [Test]
        public void TestSTForce3DM()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce3DM())
                .Single() as NTSG.LineString;

                Assert.AreEqual(3, result.CoordinateSequence.Dimension);
                var existM = result.GetCoordinateN(0).M;
                var nonExistZ = result.GetCoordinateN(0).Z;

                Assert.AreEqual(false, Double.IsNaN(existM));
                Assert.AreEqual(true, Double.IsNaN(nonExistZ));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).M);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).M);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).M);
            }
        }

        [Test]
        public void TestSTForce4D()
        {
            const string wkt = "LINESTRING(25 50, 100 125, 150 190)";
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                .Value(g => g.Id, 1)
                .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(wkt))
                .Insert();

                var result = db.TestGeometries
                .Where(g => g.Id == 1)
                .Select(g => g.Geometry.STForce4D())
                .Single() as NTSG.LineString;

                Assert.AreEqual(4, result.CoordinateSequence.Dimension);
                var existM = result.GetCoordinateN(0).M;
                var existZ = result.GetCoordinateN(0).Z;
                Assert.AreEqual(false, Double.IsNaN(existM));
                Assert.AreEqual(false, Double.IsNaN(existZ));

                Assert.AreEqual(25, result.GetCoordinateN(0).X);
                Assert.AreEqual(50, result.GetCoordinateN(0).Y);
                Assert.AreEqual(0, result.GetCoordinateN(0).M);
                Assert.AreEqual(100, result.GetCoordinateN(1).X);
                Assert.AreEqual(125, result.GetCoordinateN(1).Y);
                Assert.AreEqual(0, result.GetCoordinateN(1).M);
                Assert.AreEqual(150, result.GetCoordinateN(2).X);
                Assert.AreEqual(190, result.GetCoordinateN(2).Y);
                Assert.AreEqual(0, result.GetCoordinateN(2).M);
            }
        }
    }
}