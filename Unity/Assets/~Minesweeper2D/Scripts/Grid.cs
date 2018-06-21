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
                    if (desiredX < 0 || desiredX >= width || desiredY < 0 || desiredY >= height)
                    {
                        continue;
                    }

                    Tile currentTile = tiles[desiredX, desiredY];

                    if (currentTile.isMine)
                    {
                        count++;
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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    hitTile = hit.collider.GetComponent<Tile>();
                    explosionSound.Play();

                    if (hitTile != null)
                    {
                        SelectTile(hitTile);
                        hitTile.Reveal(adjacentMines);

                    }

                }

            }
        }

        void FFuncover(int x, int y, bool[,] visited)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                if (visited[x, y])
                    return;

                Tile tile = tiles[x, y];

                int adjacentMines = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMines);

                if (adjacentMines == 0)
                {
                    visited[x, y] = true;

                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);
                }
            }
        }

        void UncoverMines(int mineState = 0)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];

                    if (tile.isMine)
                    {
                        int adjacentMines = GetAdjacentMineCount(tile);
                        tile.Reveal(adjacentMines, mineState);
                    }
                }

            }
        }

        bool NoMoreEmptyTiles()
        {
            int emptyTileCount = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];

                    if (!tile.isRecealed && !tile.isMine)
                    {
                        emptyTileCount += 1;
                    }
                }
            }

            return emptyTileCount == 0;
        }

        void SelectTile(Tile selected)
        {
            int adjacentMines = GetAdjacentMineCount(selected);
            selected.Reveal(adjacentMines);

            if (selected.isMine)
            {
                UncoverMines();
            }

            else if (adjacentMines == 0)
            {
                int x = selected.x;
                int y = selected.y;

                FFuncover(x, y, new bool[width, height]);
            }

            if (NoMoreEmptyTiles())
            {
                UncoverMines(1);
            }
        }
    }
}
