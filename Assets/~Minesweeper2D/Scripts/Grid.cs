using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {

        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;
        public float minePercentage = 0.05f;


        private Tile[,] tiles;
        public Ray mouseRay;
        public RaycastHit2D hit;
        public Tile hitTile;
        public int adjacentMines;

        public AudioSource explosionSound;

        // Spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // Positions tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get tile components
            return currentTile; // return it
        }

        // Spawns tiles in a grid pattern
        void GenerateTile()
        {
            //Create a new 2D array of size width x height
            tiles = new Tile[width, height];

            //Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);

                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);
                    //Applies spacing
                    pos *= spacing;
                    //Spawn the tile
                    Tile tile = SpawnTile(pos);

                    // amount of tiles that is a mine is equal to a random number less than minePercentage
                    tile.isMine = Random.value < minePercentage;

                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store its array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // store tile array at those coordinates
                    tiles[x, y] = tile;

                }
            }
        }

        void Start()
        {
            // Generates tiles on start
            GenerateTile();

           
        }

        public int GetAdjacentMineCount(Tile tile)
        {
            //Set count to 0
            int count = 0;

                //Loop through all adjacent tiles on the x
                for (int x = -1; x <= 1; x++)
                {
                    //Loop through all adjacent tiles on the y
                    for (int y = -1; y <= 1; y++)
                    {
                        //Calculate which adjacnet tile to look at
                        int desiredX = tile.x + x;
                        int desiredY = tile.y + y;

                        // if desiredX >= 0 && desiredX < tiles.GetLength(0)
                        if (desiredX >= 0 && desiredX < tiles.GetLength(0))
                        {
                            if (desiredY >= 0 && desiredY < tiles.GetLength(1))
                            {
                                //Select current tile
                                Tile currentTile = tiles[desiredX, desiredY];
                                // Check if tile is a mine
                                if (currentTile.isMine)
                                {
                                    //Increment count by 1
                                    count++;
                                }
                            }
                        }



                    }
                }
   
            //Return count
            return count;
        }


        void Update()
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider != null)
                {
                    hitTile = hit.collider.GetComponent<Tile>();
                    explosionSound.Play();

                    if (hitTile != null)
                    {
                        adjacentMines = GetAdjacentMineCount(hitTile);
                        hitTile.Reveal(adjacentMines);
                        
                    }

                }

            }
        }

    }
}
