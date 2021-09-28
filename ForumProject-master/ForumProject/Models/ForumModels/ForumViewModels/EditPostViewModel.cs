using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumProject.Models.ForumModels.ForumViewModels
{
    public class EditPostViewModel
    {
        [Required]
        public int PostId { get; set; }

        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }


        public int DiscussionId { get; set; }
        public Discussion Discussion { get; set; }

        public string UserId { get; set; }

    }
}