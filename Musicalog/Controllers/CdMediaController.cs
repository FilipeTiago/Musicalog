using MediaLib.Template;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Musicalog.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musicalog.Controllers
{
    /// <summary>
    /// CD web Controller specialization.
    /// </summary>
    public class CdMediaController : GenericMediaController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="medias"></param>
        public CdMediaController(ILogger<GenericMediaController> logger, IMediaCollection medias ) : 
            base(logger, medias)
        {
        }

        [HttpGet("cd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Media>> Media([FromQuery] string Title = null, [FromQuery] string Artist = null)
        {
            return base.Media(Title, Artist);
        }

        [HttpPost("cd")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Could use the Status 201 here for Created.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Media> Media([FromBody] MediaRequest request)
        {
            return base.Media(request);
        }

        [HttpPatch("cd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Media> Media([FromBody] MediaEditRequest request)
        {
            return base.Media(request);
        }

        [HttpPatch("cd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Media([FromBody] int index)
        {
            return base.Media(index);
        }
    }
}
