CREATE TABLE postgis_geom
(
  gid   serial primary key,
  name  varchar not null,
  geom  geometry not null
);