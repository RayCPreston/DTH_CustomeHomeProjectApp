using System.ComponentModel.DataAnnotations;

namespace DTH.App.Models
{
    public class HomeProjectViewModel
    {
        [Required]
        public string? ProjectId { get; set; }

        [Required]
        public string? ProjectName { get; set; }

        [Required]
        public string? ClientName { get; set; }

        [Required]
        public string? StreetAddress { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EstimatedCompletionDate { get; set; }

        [Required]
        public string? ProjectStatus { get; set; }

        [Required]
        public decimal? Budget { get; set; }
    }
}
