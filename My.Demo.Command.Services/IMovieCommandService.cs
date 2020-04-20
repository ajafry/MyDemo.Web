using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Demo.Command.Services
{
    public interface IMovieCommandService : ICommandService<Movie>
    {
    }
}
