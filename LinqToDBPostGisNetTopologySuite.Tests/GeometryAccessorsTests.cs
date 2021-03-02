using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryAccessorsTests : TestsBase
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
        public void TestGeometryType()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

                var geometryType1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.GeometryType()).Single();
                Assert.AreEqual("LINESTRING", geometryType1);

                var stGeometryType1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STGeometryType()).Single();
                Assert.AreEqual("ST_LineString", stGeometryType1);

                var geometryType2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.GeometryType()).Single();
                Assert.IsNull(geometryType2);

                var stGeometryType2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STGeometryType()).Single();
                Assert.IsNull(stGeometryType2);
            }
        }

        [Test]
        public void TestSTBoundary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(100 150,50 60, 70 80, 160 170)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON (( 10 130, 50 190, 110 190, 140 150, 150 80, 100 10, 20 40, 10 130), (70 40, 100 50, 120 80, 80 110, 50 90, 70 40))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                const string wkt3 = "MULTILINESTRING((1 1 1,0 0 0.5, -1 1 1),(1 1 0.5,0 0 0.5, -1 1 0.5, 1 1 0.5) )";
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt3)).Insert();

                var boundary1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STBoundary().STAsText()).Single();
                Assert.AreEqual("MULTIPOINT(100 150,160 170)", boundary1);

                var boundary2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STBoundary().STAsText()).Single();
                Assert.AreEqual("MULTILINESTRING((10 130,50 190,110 190,140 150,150 80,100 10,20 40,10 130),(70 40,100 50,120 80,80 110,50 90,70 40))", boundary2);

                var boundary3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STBoundary().STAsText()).Single();
                Assert.AreEqual("MULTIPOINT Z (-1 1 1,1 1 0.75)", boundary3);
            }
        }

        [Test]
        public void TestSTCoordDim()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "CIRCULARSTRING(1 2 3, 1 3 4, 5 6 7, 8 9 10, 11 12 13)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

                var dimension1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STCoordDim()).Single();
                Assert.AreEqual(3, dimension1);

                var dimension2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STCoordDim()).Single();
                Assert.IsNull(dimension2);
            }
        }

        [Test]
        public void TestSTDimension()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION(LINESTRING(1 1,0 0),POINT(0 0))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POINT(0 0)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                var dimension1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STDimension()).Single();
                Assert.AreEqual(1, dimension1);

                var dimension2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STDimension()).Single();
                Assert.AreEqual(0, dimension2);

                var dimension3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STDimension()).Single();
                Assert.IsNull(dimension3);
            }
        }

        [Test]
        public void TestSTEndPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(1 1, 2 2, 3 3)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POINT(1 1)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var endPoint1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STEndPoint().STAsText()).Single();
                Assert.AreEqual("POINT(3 3)", endPoint1);

                var endPoint2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STEndPoint()).Single();
                Assert.IsNull(endPoint2);
            }
        }

        [Test]
        public void TestSTEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(0 0, 1 3)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var envelope = db.TestGeometries.Select(g => g.Geometry.STEnvelope().STAsText()).Single();
                Assert.AreEqual("POLYGON((0 0,0 3,1 3,1 0,0 0))", envelope);
            }
        }

        [Test]
        public void TestSTBoundingDiagonal()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () => GeometryConstructors.STMakePoint(0, 0).STBuffer(10))
                    .Insert();

                var bbBoxDiagonal = db.TestGeometries.Select(g => g.Geometry.STBoundingDiagonal().STAsText()).Single();
                Assert.AreEqual("LINESTRING(-10 -10,10 10)", bbBoxDiagonal);
            }
        }

        [Test]
        public void TestSTHasArc()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(p => p.Geometry, () =>
                    GeometryConstructors.STCollect(
                        GeometryInput.STGeomFromText("LINESTRING(1 2, 3 4, 5 6)"),
                        GeometryInput.STGeomFromText("CIRCULARSTRING(1 1, 2 3, 4 5, 6 7, 5 6)")))
                    .Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STHasArc()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STHasArc()).Single());
            }
        }

        [Test]
        public void TestSTIsClosed()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(0 0, 0 1, 1 1, 0 0)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsClosed()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsClosed()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsClosed()).Single());
            }
        }

        [Test]
        public void TestSTIsCollection()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("MULTIPOINT EMPTY")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("MULTIPOINT((0 0))")).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("MULTIPOINT((0 0), (42 42))")).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("GEOMETRYCOLLECTION(POINT(0 0))")).Insert();
                db.TestGeometries.Value(g => g.Id, 6).Value(p => p.Geometry, () => null).Insert();

                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STIsCollection()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 6).Select(g => g.Geometry.STIsCollection()).Single());
            }
        }

        [Test]
        public void TestSTIsEmpty()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION EMPTY";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON((1 2, 3 4, 5 6, 1 2))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsEmpty()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsEmpty()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsEmpty()).Single());
            }
        }

        [Test]
        public void TestSTIsRing()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 0 1, 1 1, 1 0, 0 0)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(0 0, 0 1, 1 0, 1 1, 0 0)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsRing()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsRing()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsRing()).Single());
            }
        }

        [Test]
        public void TestSTIsSimple()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POLYGON((1 1, 2 1, 2 2, 1 1))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(1 1,2 2,2 3.5,1 3,1 2,2 1)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsSimple()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsSimple()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsSimple()).Single());
            }
        }

        [Test]
        public void TestSTMemSize()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("POINT(0 0)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(32, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STMemSize()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STMemSize()).Single());
            }
        }

        [Test]
        public void TestSTNDims()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("POINT(1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("POINT(1 1 2)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("POINTM(1 1 0.5)")).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("POINTZM(1 2 3 4)")).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(2, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNDims()).Single());
                Assert.AreEqual(3, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNDims()).Single());
                Assert.AreEqual(3, db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNDims()).Single());
                Assert.AreEqual(4, db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STNDims()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STNDims()).Single());
            }
        }

        [Test]
        public void TestSTNPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "LINESTRING(77.29 29.07 1,77.42 29.26 0,77.27 29.31 -1,77.29 29.07 3)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                const string wkt3 = "LINESTRING EMPTY";
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt3)).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => null).Insert();

                var nPoints1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNPoints()).Single();
                Assert.AreEqual(1, nPoints1);

                var nPoints2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNPoints()).Single();
                Assert.AreEqual(4, nPoints2);

                var nPoints3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNPoints()).Single();
                Assert.AreEqual(0, nPoints3);

                var nPoints4 = db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STNPoints()).Single();
                Assert.IsNull(nPoints4);
            }
        }

        [Test]
        public void TestSTNumGeometries()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "GEOMETRYCOLLECTION(MULTIPOINT(-2 3 , -2 2), LINESTRING(5 5, 10 10), POLYGON((-7 4.2, -7.1 5, -7.1 4.3, -7 4.2)))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                const string wkt3 = "POINT EMPTY";
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt3)).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => null).Insert();

                var numGeometries1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumGeometries()).Single();
                Assert.AreEqual(1, numGeometries1);

                var numGeometries2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNumGeometries()).Single();
                Assert.AreEqual(3, numGeometries2);

                var numGeometries3 = db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNumGeometries()).Single();
                Assert.AreEqual(0, numGeometries3);

                var numGeometries4 = db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STNumGeometries()).Single();
                Assert.IsNull(numGeometries4);
            }
        }

        [Test]
        public void TestSTNRings()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("POLYGON((1 2, 3 4, 5 6, 1 2))")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(1, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNRings()).Single());
                Assert.AreEqual(0, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumInteriorRings()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNRings()).Single());
            }
        }

        [Test]
        public void TestSTNumPatches()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt = @"POLYHEDRALSURFACE( ((0 0 0, 0 0 1, 0 1 1, 0 1 0, 0 0 0)),
		                                ((0 0 0, 0 1 0, 1 1 0, 1 0 0, 0 0 0)), ((0 0 0, 1 0 0, 1 0 1, 0 0 1, 0 0 0)),
		                                ((1 1 0, 1 1 1, 1 0 1, 1 0 0, 1 1 0)),
		                                ((0 1 0, 0 1 1, 1 1 1, 1 1 0, 0 1 0)), ((0 0 1, 1 0 1, 1 1 1, 0 1 1, 0 0 1)) )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("POINT(1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(6, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumPatches()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNumPatches()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STNumPatches()).Single());
            }
        }

        [Test]
        public void TestSTNumPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POINT(77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var numPoints1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumPoints()).Single();
                Assert.AreEqual(4, numPoints1);

                var numPoints2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNumPoints()).Single();
                Assert.IsNull(numPoints2);
            }
        }

        [Test]
        public void TestSTPatchN()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Ewkt = @"POLYHEDRALSURFACE( ((0 0 0, 0 0 1, 0 1 1, 0 1 0, 0 0 0)),
	                ((0 0 0, 0 1 0, 1 1 0, 1 0 0, 0 0 0)), ((0 0 0, 1 0 0, 1 0 1, 0 0 1, 0 0 0)),
	                ((1 1 0, 1 1 1, 1 0 1, 1 0 0, 1 1 0)),
	                ((0 1 0, 0 1 1, 1 1 1, 1 1 0, 0 1 0)), ((0 0 1, 1 0 1, 1 1 1, 0 1 1, 0 0 1)) )";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT(Ewkt)).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("POINT(1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual("POLYGON((0 0 0,0 1 0,1 1 0,1 0 0,0 0 0))", db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STPatchN(2).STAsEWKT()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STPatchN(1)).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STPatchN(1)).Single());
            }
        }

        [Test]
        public void TestSTPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POLYGON Z ((30 10 4,10 30 5,40 40 6, 30 10 4))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(Wkt)).Insert();

                var points = db.TestGeometries.Select(g => g.Geometry.STPoints().STAsText()).Single();
                Assert.AreEqual("MULTIPOINT Z (30 10 4,10 30 5,40 40 6,30 10 4)", points);
            }
        }

        [Test]
        public void TestSTStartPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 1, 0 2)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POINT(0 1)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var startPoint1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STStartPoint().STAsText()).Single();
                Assert.AreEqual("POINT(0 1)", startPoint1);

                var startPoint2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STStartPoint()).Single();
                Assert.IsNull(startPoint2);
            }
        }

        [Test]
        public void TestSTSummary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText("LINESTRING(0 0, 1 1)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual("LineString[] with 2 points", db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STSummary()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STSummary()).Single());
            }
        }

        [Test]
        public void TestSTXYZM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 2 3 4)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                const string wkt3 = "POINT EMPTY";
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt3)).Insert();

                var query1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(1, query1.Select(g => g.Geometry.STX()).Single());
                Assert.AreEqual(2, query1.Select(g => g.Geometry.STY()).Single());
                Assert.AreEqual(3, query1.Select(g => g.Geometry.STZ()).Single());
                Assert.AreEqual(4, query1.Select(g => g.Geometry.STM()).Single());

                var query2 = db.TestGeometries.Where(g => g.Id == 2);
                Assert.AreEqual(1, query2.Select(g => g.Geometry.STX()).Single());
                Assert.AreEqual(2, query2.Select(g => g.Geometry.STY()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STZ()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STM()).Single());

                var query3 = db.TestGeometries.Where(g => g.Id == 3);
                Assert.IsNull(query3.Select(g => g.Geometry.STX()).Single());
                Assert.IsNull(query3.Select(g => g.Geometry.STY()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STZ()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STM()).Single());
            }
        }

        [Test]
        public void TestSTZmflag()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("LINESTRING(1 2, 3 4)")).Insert();
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("LINESTRINGM(1 2 3, 3 4 3)")).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("CIRCULARSTRING(1 2 3, 3 4 3, 5 6 3)")).Insert();
                db.TestGeometries.Value(g => g.Id, 4).Value(p => p.Geometry, () => GeometryInput.STGeomFromEWKT("POINT(1 2 3 4)")).Insert();
                db.TestGeometries.Value(g => g.Id, 5).Value(p => p.Geometry, () => null).Insert();

                Assert.AreEqual(0, db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STZmflag()).Single());
                Assert.AreEqual(1, db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STZmflag()).Single());
                Assert.AreEqual(2, db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STZmflag()).Single());
                Assert.AreEqual(3, db.TestGeometries.Where(g => g.Id == 4).Select(g => g.Geometry.STZmflag()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 5).Select(g => g.Geometry.STZmflag()).Single());
            }
        }
    }
}
