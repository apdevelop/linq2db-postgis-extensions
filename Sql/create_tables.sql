-- Enable the PostGIS extension for the database:
-- CREATE EXTENSION postgis;

-- Check the PostGIS presense and version.
-- SELECT PostGIS_Full_Version();

CREATE TABLE owm_cities
(
  id		integer primary key,
  city_name	varchar not null,
  geom		geometry not null
);

CREATE TABLE test_geometry
(
  id	integer primary key,
  geom	geometry
);

CREATE TABLE test_geography
(
  id	integer primary key,
  geog	geography
);
