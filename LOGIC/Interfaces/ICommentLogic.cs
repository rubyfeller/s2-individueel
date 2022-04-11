﻿using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ICommentLogic
    {
        Object AddComment(CommentDTO commentDto);
        Boolean DeleteComment(int commentid);
    }
}
