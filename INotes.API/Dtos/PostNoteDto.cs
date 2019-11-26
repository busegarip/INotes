﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INotes.API.Dtos
{
    public class PostNoteDto
    {
        [Required(ErrorMessage ="Başlıkalanı zorunludur.")]
        [StringLength(100, ErrorMessage ="Başlık {2} karakteri geçemez.")]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}