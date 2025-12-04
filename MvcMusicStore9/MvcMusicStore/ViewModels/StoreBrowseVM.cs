using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.ViewModels;
using MvcMusicStore.Models;

namespace MvcMusicStore.ViewModels
{
    public class StoreBrowseVM
    {
        public Genre? Genre { get; set; }
        public List<Album>? Albums { get; set; }
    }
}