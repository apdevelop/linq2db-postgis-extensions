using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;
using NTSG = NetTopologySuite.Geometries;

using LinqToDBPostGisNetTopologySuite.Tests.Entities;
namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class AffineTransformationsTests : TestsBase
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
        public void TestSTAffine3D()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 4 3)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g =>
                        g.Geometry.STAffine(Math.Cos(Math.PI),
                            -1 * Math.Sin(Math.PI), 0, Math.Sin(Math.PI), Math.Cos(Math.PI), 0, 0, 0, 1, 0, 0, 0)
                    )
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                ;
                Assert.AreEqual("LINESTRING(-1 -2 3,-1 -4 3)", result);
            }
        }

        [Test]
        public void TestSTAffine2D()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 4 3)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g =>
                        g.Geometry.STAffine(0, 0, 0, 0, 0, 0)
                    )
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                ;
                Assert.AreEqual("LINESTRING(0 0 3,0 0 3)", result);
            }
        }
        [Test]
        public void TestSTRotate()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING (50 160, 50 50, 100 50)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotate(Math.PI))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(-50.00000000000002 -160,-50.00000000000001 -49.99999999999999,-100 -49.999999999999986)");
            }
        }
        [Test]
        public void TestSTRotateOrigin()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING (50 160, 50 50, 100 50)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotate(Math.PI / 6.0, 50, 160))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(50 160,104.99999999999999 64.73720558371174,148.30127018922192 89.73720558371173)");
            }
        }

        [Test]
        public void TestSTRotateOriginGeom()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING (50 160, 50 50, 100 50)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotate(-1.0 * Math.PI / 3.0, g.Geometry.STCentroid()))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(116.42245883568916 130.67207346706593,21.15966441940092 75.67207346706593,46.15966441940093 32.370803277844)");
            }
        }

        [Test]
        public void TestSTRotateX()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotateX(Math.PI / 2.0))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(1 -3 2,1 -1 1)");
            }
        }
        [Test]
        public void TestSTRotateY()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotateY(Math.PI / 2.0))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(3 2 -1,1 1 -1)");
            }
        }
        [Test]
        public void TestSTRotateZ()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotateZ(Math.PI / 2.0))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(-2 1 3,-1 1 1)");
            }
        }
        [Test]
        public void TestSTScaleXYZ()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(0.5, 0.75, 0.8))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(0.5 1.5 2.4,0.5 0.75 0.8)");
            }
        }
        [Test]
        public void TestSTScaleXY()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(0.5, 0.75))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(0.5 1.5 3,0.5 0.75 1)");
            }
        }
        [Test]
        public void TestSTScaleXYZM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 2 3 4, 1 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(GeometryConstructors.STMakePoint(0.5, 0.75, 2, -1)))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(0.5 1.5 6 -4,0.5 0.75 2 -1)");
            }
        }
        [Test]
        public void TestSTScaleFalseOrigin()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string ewkt = "LINESTRING(1 1, 2 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(ewkt)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(GeometryInput.STGeomFromEWKT("POINT(2 2)"), GeometryInput.STGeomFromEWKT("POINT(1 1)")))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(1 1,3 3)");
            }
        }
        [Test]
        public void TestSTTranslatedXY()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string geomText = "POINT(-71.01 42.37)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(geomText, 4326)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STTranslate(1, 0))
                    .Select(g => GeometryOutput.STAsText(g))
                    .Single();
                Assert.AreEqual(result, "POINT(-70.01 42.37)");
            }
        }
        [Test]
        public void TestSTTranslatedXYZ()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string geomText = "POINT(0 0 0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(geomText)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STTranslate(5, 12, 3))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "POINT(5 12 3)");
            }
        }
        [Test]
        public void TestSTTransScale()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string geomText = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(geomText)).Insert();
                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STTransScale(0.5, 1, 1, 2))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();
                Assert.AreEqual(result, "LINESTRING(1.5 6 3,1.5 4 1)");
            }
        }
    }
}