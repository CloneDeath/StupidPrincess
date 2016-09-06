using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using StupidPrincess.Game.MainGame.Entities;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.MazeLoading
{
    public class EntityLegend
    {
        private static readonly Dictionary<string, Func<Position, Maze, IEntity>> _entityMap = new Dictionary<string, Func<Position, Maze, IEntity>> {
            { "Wall", (p, m) => new Wall(p) },
            { "Princess", (p, m) => new Princess(p, m) },
            { "Orc", (p, m) => new Orc(p) },
            { "Key", (p, m) => new Key(p) },
            { "Door", (p, m) => new Door(p) }
        };

        private readonly Dictionary<char, string> _symbolComponentMap = new Dictionary<char, string>(); 

        public void Parse(string current) {
            var equation = Regex.Match(current, @"\s*(.)\s*=\s*(.+)\s*");
            var symbol = equation.Groups[1].Value[0];
            var component = equation.Groups[2].Value;
            _symbolComponentMap[symbol] = component;
        }

        public IEntity GetEntity(char symbol, Position position, Maze maze) {
            if (symbol == ' ') return null;
            if (!_symbolComponentMap.ContainsKey(symbol)) throw new NotImplementedException($"Unrecognized Symbol '{symbol}' at Position {position} in the map!");

            var component = _symbolComponentMap[symbol];
            var entityParams = component.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            var entity = _entityMap[entityParams.Last()](position, maze);

            var entityArguments = entityParams.Take(entityParams.Length - 1);

            LoadEntityArguments(entity, entityArguments);

            return entity;
        }

        private static void LoadEntityArguments(IEntity entity, IEnumerable<string> entityArguments) {
            var keyEntity = entity as Key;
            if (keyEntity != null) {
                if (entityArguments.Any(a => a.ToUpper() == "RED")) keyEntity.Color = LockColor.Red;
                if (entityArguments.Any(a => a.ToUpper() == "BLUE")) keyEntity.Color = LockColor.Blue;
            }

            var doorEntity = entity as Door;
            if (doorEntity != null) {
                if (entityArguments.Any(a => a.ToUpper() == "RED")) doorEntity.Color = LockColor.Red;
                if (entityArguments.Any(a => a.ToUpper() == "BLUE")) doorEntity.Color = LockColor.Blue;
            }
        }
    }
}