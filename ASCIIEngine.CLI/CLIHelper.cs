﻿using ASCIIEngine.Core.BasicClasses;
using Colorful;

namespace ASCIIEngine.CLI
{
    public static class CLIHelper
    {
        /// <summary>
        /// Draws a given material rectangle from start (inclusive) to end (inclusive) with an outer ring
        /// </summary>
        /// <param name="start">Starting coordinate in console coordinates (X goes down, Y goes right)</param>
        /// <param name="end">End coordinate in console coordinates (X goes down, Y goes right)</param>
        /// <param name="outerMaterial">Material to fill the rectangle</param>
        /// <param name="innerMaterial">Material to draw the ring</param>
        public static void DrawRect(Vector2D start, Vector2D end, Material outerMaterial, Material innerMaterial)
        {
            Console.ForegroundColor = innerMaterial.ForegroundColor;
            Console.BackgroundColor = innerMaterial.BackgroundColor;

            for (var y = start.Y + 1; y <= end.Y - 1; y++)
            {
                Console.SetCursorPosition(start.X + 1, y);

                for (var x = start.X + 1; x <= end.X - 1; x++)
                {
                    Console.Write(innerMaterial.Character);
                }
            }

            // Bounds
            DrawRect(start, new Vector2D(end.X, start.Y), outerMaterial);
            DrawRect(new Vector2D(end.X, start.Y), end, outerMaterial);
            DrawRect(new Vector2D(start.X, end.Y), end, outerMaterial);
            DrawRect(start, new Vector2D(start.X, end.Y), outerMaterial);
        }

        /// <summary>
        /// Draws a given buffer to the console, starting at base point
        /// </summary>
        /// <param name="buffer">Buffer to draw</param>
        /// <param name="basePoint">BasePoint in console coordinates (X goes down, Y goes right)</param>
        public static void DrawArray(Material[,] buffer, Vector2D basePoint)
        {
            for (var i = 0; i < buffer.GetLength(0); i++)
            {
                for (var j = 0; j < buffer.GetLength(1); j++)
                {
                    if (buffer[i, j].Character == '\0')
                        continue;
                    var obj = buffer[i, j];
                    Console.ForegroundColor = obj.ForegroundColor;
                    Console.BackgroundColor = obj.BackgroundColor;
                    Console.SetCursorPosition(i * 2 + basePoint.X, (buffer.GetLength(1) - 1) - j + basePoint.Y);
                    Console.Write(obj.Character);
                    if (i > 0)
                    {
                        Console.SetCursorPosition(i * 2 + basePoint.X - 1 , (buffer.GetLength(1) - 1) - j + basePoint.Y);
                        Console.Write('\0');
                    }
                }
            }
        }

        /// <summary>
        /// Draws a given material rectangle from start (inclusive) to end (inclusive)
        /// </summary>
        /// <param name="start">Starting coordinate in console coordinates (X goes down, Y goes right)</param>
        /// <param name="end">End coordinate in console coordinates (X goes down, Y goes right)</param>
        /// <param name="material">Material to fill the rectangle</param>
        private static void DrawRect(Vector2D start, Vector2D end, Material material)
        {
            Console.ForegroundColor = material.ForegroundColor;
            Console.BackgroundColor = material.BackgroundColor;

            for (var y = start.Y; y <= end.Y; y++)
            {
                Console.SetCursorPosition(start.X, y);

                for (var x = start.X; x <= end.X; x++)
                {
                    Console.Write(material.Character);
                }
            }
        }
    }
}