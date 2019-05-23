using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESportsLeaderboardMVC.Models;
using ESportsLeaderboardMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESportsLeaderboardMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepo;

        public PlayerController(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<ActionResult<List<Player>>> Index()
        {
            // Retreives an unsorted list of players from the repo
            var playerList = await _playerRepo.GetListOfPLayersAsync();

            // The player list will be sorted in decending order based on the total number of subscribers
            playerList.Sort((a,b) => -1* a.TotalSubscribers.CompareTo(b.TotalSubscribers));

            // Loop through each player in the playerList
            for (int i = 0; i < playerList.Count(); i++)
            {
                // Assigns a currnet ranking for each player. Ranked from 1 to infinity for each player in the list.
                // Players at the front of the list are given the "top" rank of 1 onward. 
                playerList[i].CurrentRank = i+1;

                // HighestRank is intended to keep record of the highest ranking a player has acheived. 
                // If their current rank is higher than their previous rank, Highest rank is replaced with the current rank
                if (playerList[i].HighestRank <= playerList[i].CurrentRank)
                {
                    playerList[i].HighestRank = playerList[i].CurrentRank;
                }
            }
            return playerList;
        }
    }
}