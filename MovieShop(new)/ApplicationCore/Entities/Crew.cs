﻿namespace ApplicationCore.Entities
{
     public class Crew
     {
          public int Id { get; set; }
          public string? Name { get; set; }
          public string? Gender { get; set; }
          public string? TmdbUrl { get; set; }
          public string? ProfilePath { get; set; }

          public List<MovieCrew> MovieCrews { get; set; }
     }
}