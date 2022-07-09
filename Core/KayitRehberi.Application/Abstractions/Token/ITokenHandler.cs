using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = KayitRehberi.Application.DTOs;

namespace KayitRehberi.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
     T.Token CreateAccessToken(int minute);
    }
}
