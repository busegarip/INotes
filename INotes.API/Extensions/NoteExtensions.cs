using INotes.API.Dtos;
using INotes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INotes.API.Extensions
{
    public static class NoteExtensions
    {
        public static GetNoteDto ToGetNoteDto(this Note note)//getnotedto girdi note çıktı
        {

            return new GetNoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedTime = note.CreatedTime,
                ModifiedTime = note.ModifiedTime
            };
        }
    }
}