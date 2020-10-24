create table table_samples (
  "id" serial not null,
  "code" text not null,
  "name" text null,
  "created_at" timestamp not null
);

insert into table_sample values
  (1, 'code1', 'NameOne', clock_timestamp()),
  (2, 'code2', 'NameTwo', clock_timestamp());
