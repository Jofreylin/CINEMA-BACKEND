using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Keyless]
public partial class MoviesByScreensView
{
    public int MovieByScreenId { get; set; }

    public int MovieId { get; set; }

    public int ScreenId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ShowingDate { get; set; }

    public TimeSpan? ShowingHour { get; set; }

    [Column(TypeName = "numeric(12, 2)")]
    public decimal? PriceBySeat { get; set; }

    public bool? IsHoliday { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? HolidayName { get; set; }

    public bool IsRecordActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastModificationAt { get; set; }

    public int? LastModificationByUserId { get; set; }
}
