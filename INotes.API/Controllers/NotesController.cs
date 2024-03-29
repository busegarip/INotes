﻿using INotes.API.Dtos;
using INotes.API.Extensions;
using INotes.API.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INotes.API.Controllers
{
    [Authorize]//buraya elini kolunu sallayan giremesin
    public class NotesController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult GetNotes()//o an login olmuş olan kullanıcı kim ise onun notlarını göstermeli
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            return Ok(user.Notes.Select(x => x.ToGetNoteDto()).ToList());
        }
        public IHttpActionResult GetNote(int id)//o an login olmuş olan kullanıcı kim ise onun notlarını göstermeli
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            return Ok(user.Notes
                .Where(x => x.Id == id)
                .Select(x => x.ToGetNoteDto()).FirstOrDefault());
        }

        public IHttpActionResult PostNote(PostNoteDto dto)
        {
            if (ModelState.IsValid)
            {
                var note = new Note
                {
                    Title = dto.Title,
                    Content = dto.Content,
                    CreatedTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    AuthorId = User.Identity.GetUserId()
                };
                db.Notes.Add(note);
                db.SaveChanges();
                return Ok(note.ToGetNoteDto());
            }
            return BadRequest(ModelState);
        }

        //PUT: api/Notes/PutNote/1
        public IHttpActionResult PutNote(int id, PutNoteDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            
            var note = db.Notes.Find(id);

            if (note==null)
            {
                return NotFound();//hata döndürüyor 404 status kodları farklı
            }

            if (note.AuthorId != User.Identity.GetUserId())
            {
                return Unauthorized();//değiştirmek istediğin yazı sana ait mi değilse yetkin yok demesi lazım status 401
            }
            
            if (ModelState.IsValid)
            {
                note.Title = dto.Title;
                note.Content = dto.Content;
                note.ModifiedTime = DateTime.Now;
                db.SaveChanges();

                return Ok(note.ToGetNoteDto());
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult DeleteNote(int id)
        {
            var note = db.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            if (note.AuthorId != User.Identity.GetUserId())
            {
                return Unauthorized();//değiştirmek istediğin yazı sana ait mi değilse yetkin yok demesi lazım
            }

            db.Notes.Remove(note);
            db.SaveChanges();
            return Ok(note.ToGetNoteDto());//silineni döndürdük.
        }
    }
}
