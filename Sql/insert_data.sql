INSERT INTO postgis_geom (name, geom) VALUES ('Point 1', 'POINT(0 0)');
INSERT INTO postgis_geom (name, geom) VALUES ('Point 2', 'POINT(10 20)');
INSERT INTO postgis_geom (name, geom) VALUES ('Point 3', 'POINT(100 200)');
INSERT INTO postgis_geom (name, geom) VALUES ('Point A', 'SRID=3857;POINT(10 10)');
INSERT INTO postgis_geom (name, geom) VALUES ('Point B', 'SRID=3857;POINT(25 15)');

INSERT INTO test_polygons (name, geom) VALUES ('Square at zero', 'SRID=3857;POLYGON((0 0, 10 0, 10 10, 0 10, 0 0))');
INSERT INTO test_polygons (name, geom) VALUES ('Rectangle H', 'SRID=3857;POLYGON((20 20, 70 20, 70 40, 20 40, 20 20))');
INSERT INTO test_polygons (name, geom) VALUES ('Rectangle V', 'SRID=3857;POLYGON((0 20, 10 20, 10 50, 0 50, 0 20))');

INSERT INTO owm_cities (city_name, geom) VALUES ('Paris',  'SRID=4326;POINT(2.348800 48.853409)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Berlin', 'SRID=4326;POINT(13.410530 52.524368)');
INSERT INTO owm_cities (city_name, geom) VALUES ('London', 'SRID=4326;POINT(-0.091840 51.512791)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Prague', 'SRID=4326;POINT(14.420760 50.088039)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Moscow', 'SRID=4326;POINT(37.615555 55.752220)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Minsk',  'SRID=4326;POINT(27.566668 53.900002)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Madrid', 'SRID=4326;POINT(-3.702560 40.416500)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Warsaw', 'SRID=4326;POINT(21.011780 52.229771)');
INSERT INTO owm_cities (city_name, geom) VALUES ('Vienna', 'SRID=4326;POINT(16.372080 48.208488)');


ALTER TABLE owm_cities
  ALTER COLUMN geom TYPE geometry(POINT, 3857) 
    USING ST_Transform(ST_SetSRID(geom, 4326), 3857);

CREATE INDEX owm_cities_index ON owm_cities USING GIST(geom);