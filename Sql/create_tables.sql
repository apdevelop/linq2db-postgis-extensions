CREATE TABLE postgis_geom
(
  gid   serial primary key,
  name  varchar not null,
  geom  geometry not null
);

CREATE TABLE test_polygons
(
  gid   serial primary key,
  name  varchar not null,
  geom  geometry not null
);

CREATE TABLE owm_cities
(
  gid        serial primary key,
  city_name  varchar not null,
  geom       geometry not null
);

CREATE TABLE test_geometry
(
  id   integer primary key,
  geom  geometry
);