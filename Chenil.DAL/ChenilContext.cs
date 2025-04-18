using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chenil.DAL
{
    public class ChenilContext(DbContextOptions options) : DbContext (options)
    {

    }
}
