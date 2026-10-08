using System;
using System.Collections.Generic;
using App.Domain.Core.Product.Entities;
namespace App.Domain.Core.BaseData.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Rate { get; set; }

    public string? Comments { get; set; }

    public int ProductId { get; set; }

    public DateTime CommentTime { get; set; }

    public int StatusId { get; set; }

    public int SubmitUserId { get; set; }

    public DateTime LastEditTime { get; set; }

    public int? EditoroperatorId { get; set; }

    public int? LikeCount { get; set; }

    public int? DisLikeCount { get; set; }

    public int? ParentCommentId { get; set; }

    public virtual EditorOperator? Editoroperator { get; set; }

    public virtual ICollection<Comment> InverseParentComment { get; set; } = new List<Comment>();

    public virtual Comment? ParentComment { get; set; }

    public virtual App.Domain.Core.Product.Entities.Product Product { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual SubmitUser SubmitUser { get; set; } = null!;
}
