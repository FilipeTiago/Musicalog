using MediaLib.Enums;
using MediaLib.Helpers;
using MediaLib.Interfaces;
using MediaLib.Medias;
using MediaLib.SearchRules;
using MediaLib.Template;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Musicalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musicalog.Controllers
{
    /// <summary>
    /// Base mediaController with the generic methods, this way a specific media type can rewrite the method if needed.
    /// </summary>
    public abstract class GenericMediaController : Controller
    {
        private readonly ILogger<GenericMediaController> _logger;
        private IMediaCollection _medias;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="medias"></param>
        public GenericMediaController(ILogger<GenericMediaController> logger, IMediaCollection medias )
        {
            _logger = logger;
            _medias = medias;
        }

        /// <summary>
        /// GET media, can apply filters to the search using a query string.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Artist"></param>
        /// <returns></returns>
        [HttpGet("media")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Media>> Media([FromQuery]string Title = null, [FromQuery] string Artist = null)
        {
            var MatchRules = new List<IMatchRule<Media>>();
            if (!string.IsNullOrEmpty(Title)) MatchRules.Add(
                new MatchByTitle(
                    new StringSearchRule() { 
                        Text = Title, 
                        ExactMatch = false, 
                        StringComparison = StringComparison.InvariantCultureIgnoreCase 
                    }));

            if (!string.IsNullOrEmpty(Artist)) MatchRules.Add(
                new MatchByArtist(
                    new StringSearchRule() { 
                        Text = Artist, 
                        ExactMatch = false, 
                        StringComparison = StringComparison.InvariantCultureIgnoreCase 
                    }));

            var response = MatchRules.Any() ? SearchEngine.Search(_medias.List, MatchRules).ToList() : _medias.List;
            
            if (response.Any()) return response.ToList();
            else return Ok();
        }

        /// <summary>
        /// POST Add a media item.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("media")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Could use the Status 201 here for Created.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Media> Media([FromBody]MediaRequest request)
        {
            if (request.Type == MediaType.Cd) _medias.Add(new Cd() { Title = request.Title, Artist = request.Artist, Stock = request.Stock });
            else if (request.Type == MediaType.Vinyl) _medias.Add(new Vinyl() { Title = request.Title, Artist = request.Artist, Stock = request.Stock });
            else return BadRequest();
            return Ok(_medias.List.Last());
        }

        /// <summary>
        /// PATCH edit a media item.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("media")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Media> Media ([FromBody]MediaEditRequest request)
        {
            if (_medias.List.Count() > request.Index) return NotFound();
            if (request.Type == MediaType.Cd) _medias.Edit(request.Index, new Cd() { Title = request.Title, Artist = request.Artist, Stock = request.Stock });
            else if (request.Type == MediaType.Vinyl) _medias.Edit(request.Index, new Vinyl() { Title = request.Title, Artist = request.Artist, Stock = request.Stock });
            else return BadRequest();
            return Ok(_medias.Get(request.Index));
        }

        /// <summary>
        /// PATCH delete a media item.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpPatch("media")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Media([FromBody] int index)
        {
            if (_medias.List.Count() > index) return NotFound();
            _medias.Delete(index);
            return Ok();
        }
    }
}
