using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.Character
{
    public class GetCharacterDto
    {
    public int Id { get; set; }
    public string Name { get; set; } = "Cra";
    public int HitPoint { get; set; } = 69;
    public int Strenght { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}