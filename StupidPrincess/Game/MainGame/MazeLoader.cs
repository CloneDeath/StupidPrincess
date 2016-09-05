using System;
using System.IO;
using System.Linq;
using StupidPrincess.Game.MainGame.Entities;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame
{
    public static class MazeLoader
    {
        public static Maze Load(string filePath) {
            var fileLines = File.ReadAllLines(filePath);
            var height = fileLines.Length;
            var width = fileLines.Max(l => l.Length);
            var maze = new Maze(new Size(width, height));
            PopulateMaze(fileLines, maze);
            return maze;
        }

        private static void PopulateMaze(string[] fileLines, Maze maze) {
            for (var y = 0; y < fileLines.Length; y++) {
                for (var x = 0; x < fileLines[y].Length; x++) {
                    var symbol = fileLines[y][x];
                    var entity = GetEntity(new Position(x, y), symbol);
                    if (entity == null) continue;
                    maze.AddEntity(entity);
                }
            }
        }

        private static IEntity GetEntity(Position position, char symbol) {
            switch (symbol) {
                case '#':
                    return new Wall(position);
                case 'P':
                    return new Princess(position);
                case 'O':
                    return new Orc(position);
                case 'K':
                    return new Key(position);
                case 'D':
                    return new Door(position);
                case ' ':
                    return null;
                default:
                    throw new NotImplementedException($"Symbol not recognized in map file '{symbol}', at ({position.X}, {position.Y})");
            }
        }
    }
}
