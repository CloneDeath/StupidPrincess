using StupidPrincess.Game.MainGame.Entities;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.MazeLoading
{
    public static class MazeLoader
    {
        public static Maze Load(string filePath) {
            var fileLines = new FileStack(filePath);
            var entityLegend = new EntityLegend();
            while (fileLines.Current != "BEGIN") {
                entityLegend.Parse(fileLines.Current);
                fileLines.Advance();
            }
            var maze = new Maze(fileLines.MazeSize);
            PopulateMaze(maze, entityLegend, fileLines.RemainingLines);
            return maze;
        }

        private static void PopulateMaze(Maze maze, EntityLegend legend, string[] fileLines) {
            for (var y = 0; y < fileLines.Length; y++) {
                for (var x = 0; x < fileLines[y].Length; x++) {
                    var symbol = fileLines[y][x];
                    var entity = legend.GetEntity(symbol, new Position(x, y), maze);
                    if (entity == null) continue;
                    maze.AddEntity(entity);
                }
            }
        }
    }
}
