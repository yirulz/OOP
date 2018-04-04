using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Tile : MonoBehaviour
    {

        // Store x and y coordinates in array for later use
        public int x = 0;
        public int y = 0;
        public bool isMine = false; // Is current tile a mine?
        public bool isRecealed = false; // Has the tile been revealed
        [Header("References")]
        public Sprite[] emptySprites; // List of empty sprites
        public Sprite[] mineSprites; // Mine sprites

        private SpriteRenderer rend; // Reference to sprite renderer

        void Awake()
        {
            //Grabs Reference to sprite renderer
            rend = GetComponent<SpriteRenderer>();
        }

         void Start()
        {
           // isMine = Random.value < 0.5f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // Flags the title as being revealed
            isRecealed = true;
            // Check if tile is a mine
            if(isMine)
            {
                // Set sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                // Set sprite to appropriate texture based on adjacent tiles
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}