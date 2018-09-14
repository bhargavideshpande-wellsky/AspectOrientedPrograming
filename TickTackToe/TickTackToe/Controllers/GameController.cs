using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TickTackToe.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        static string[] checkBoard = new string[9];
        static List<string> tokenContainer = new List<string>();
        static int count = 0;
        static string temp = "" , result="", result1="";
        
        [Log]
        [Authorize]
        [HttpPost]
        public string MakeMove([FromHeader]string apiKey, [FromBody]int boxId)
        {

            if (!tokenContainer.Contains(apiKey) && tokenContainer.Count < 2)
            {
                tokenContainer.Add(apiKey);
                if (apiKey != temp)
                {
                    if (checkBoard[boxId - 1] != null)
                    {
                        throw new Exception("Invalid Move!");
                    }
                    else
                    {
                        checkBoard[boxId - 1] = apiKey;
                        temp = apiKey;
                        count++;
                    }
                }
            }
            else if (!tokenContainer.Contains(apiKey) && tokenContainer.Count == 2)
            {
                throw new Exception("Only two players can play at a time! ");
            }
            else if (tokenContainer.Contains(apiKey) && tokenContainer.Count <= 2)
            {
                if(apiKey != temp)
                {
                    if (checkBoard[boxId - 1] != null)
                    {
                        throw new Exception("Invalid Move!");
                    }
                    else
                    {
                        checkBoard[boxId - 1] = apiKey;
                        temp = apiKey;
                        count++;
                    }
                }
                else
                {
                    throw new Exception("You cann't play one more time!");
                }
                
            }
            if(count==1)
            {
                throw new Exception("Only one player is present!");
            }

            if (count >= 5)
            {
                result = getStatus();
            }
            else
            {
                result = "In Progress..";
            }
            return result;
            
        }

        public string getStatus()
        {
            if((checkBoard[0]==tokenContainer[0] && checkBoard[1]==tokenContainer[0] && checkBoard[2] == tokenContainer[0]) || 
                (checkBoard[3] == tokenContainer[0] && checkBoard[4] == tokenContainer[0] && checkBoard[5] == tokenContainer[0]) || 
                (checkBoard[6] == tokenContainer[0] && checkBoard[7] == tokenContainer[0] && checkBoard[8] == tokenContainer[0]) || 
                (checkBoard[0] == tokenContainer[0] && checkBoard[3] == tokenContainer[0] && checkBoard[6] == tokenContainer[0]) || 
                (checkBoard[1] == tokenContainer[0] && checkBoard[4] == tokenContainer[0] && checkBoard[7] == tokenContainer[0]) || 
                (checkBoard[2] == tokenContainer[0] && checkBoard[5] == tokenContainer[0] && checkBoard[8] == tokenContainer[0]) || 
                (checkBoard[0] == tokenContainer[0] && checkBoard[4] == tokenContainer[0] && checkBoard[8] == tokenContainer[0]) || 
                (checkBoard[2] == tokenContainer[0] && checkBoard[4] == tokenContainer[0] && checkBoard[6] == tokenContainer[0]))
            {
                result1 = "Player One Wins..!";
            }
            else if((checkBoard[0] == tokenContainer[1] && checkBoard[1] == tokenContainer[1] && checkBoard[2] == tokenContainer[1]) ||
                (checkBoard[3] == tokenContainer[1] && checkBoard[4] == tokenContainer[1] && checkBoard[5] == tokenContainer[1]) ||
                (checkBoard[6] == tokenContainer[1] && checkBoard[7] == tokenContainer[1] && checkBoard[8] == tokenContainer[1]) ||
                (checkBoard[0] == tokenContainer[1] && checkBoard[3] == tokenContainer[1] && checkBoard[6] == tokenContainer[1]) ||
                (checkBoard[1] == tokenContainer[1] && checkBoard[4] == tokenContainer[1] && checkBoard[7] == tokenContainer[1]) ||
                (checkBoard[2] == tokenContainer[1] && checkBoard[5] == tokenContainer[1] && checkBoard[8] == tokenContainer[1]) ||
                (checkBoard[0] == tokenContainer[1] && checkBoard[4] == tokenContainer[1] && checkBoard[8] == tokenContainer[1]) ||
                (checkBoard[2] == tokenContainer[1] && checkBoard[4] == tokenContainer[1] && checkBoard[6] == tokenContainer[1]))
            {
                result1 = "Player Two Wins..!";
            }
            else if(count == 9)
            {
                result1 = "Draw!!";
            }
            else
            {
                result1 = "In Progress..";
            }

            return result1;

        }


    }
}