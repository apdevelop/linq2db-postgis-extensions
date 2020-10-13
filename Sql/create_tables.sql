CREATE TABLE owm_cities
(
  id   integer primary key,
  city_name  varchar not null,
  geom       geometry not null
);

CREATE TABLE test_geometry
(
  id   integer primary key,
  geom  geometry
);