﻿using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Roguelike.Systems
{

    // Represents a queue of messages that can be added to by drawing to a RLConsole.
    public class MessageLog
    {
        // Define the maximum number of lines to store.
        private static readonly int _maxLines = 9;

        // Use a queue to keep track of the lines of text.  The first line added will also be the first line removed.
        private readonly Queue<string> _lines;

        public MessageLog()
        {
            _lines = new Queue<string>();
        }

        // Add a line to the MessageLog queue.
        public void Add(string message)
        {
            _lines.Enqueue(message);

            // When exceeding the maximum number of lines, remove the oldest one.
            if(_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        // Draw each line of the MessageLog queue to the console.
        public void Draw(RLConsole console)
        {
            string[] lines = _lines.ToArray();
            for(int i = 0; i < lines.Length; i++)
            {
                console.Print(1, i + 1, lines[i], RLColor.White);
            }
        }
    }
}
