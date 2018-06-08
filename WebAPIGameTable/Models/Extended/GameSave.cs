using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIGameTable.Models.Extended
{
    [MetadataType(typeof(GameMetadata))]
    public class GameSave
    {
       
    }
    public class GameMetadata
    {
        [Required (AllowEmptyStrings = false,ErrorMessage = "Error")]
        public string Game { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Error")]
        public string ReleaseYear { get; set; }

    }

}