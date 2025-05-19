﻿nusing Microsoft.AspNetCore.Mvc;
amespace LevelUpAPI.Models

{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
    }
}