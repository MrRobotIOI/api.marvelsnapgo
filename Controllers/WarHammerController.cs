using System.Net;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarHammer40KAPI.Data;
using WarHammer40KAPI.Entities;
using WarHammer40KAPI.MarvelApi;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace WarHammer40KAPI.Controllers;
[Route("*api/[controller]")]
[ApiController]

public class WarHammerController : Controller
{
    private readonly DataContext _context;
    // GET
    public WarHammerController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("/marvelsnap/")]
    public async Task<ActionResult> GetNames_R1()
    {
        string namesString =
            "Abomination\nAdam Warlock\nAero\nAgatha Harkness\nAgent 13\nAmerica Chavez\nAngel\nAngela\nAnnihilus\nAnt Man\nApocalypse\nArishem\nArmor\nArnim Zola\nAttuma\nBaron Mordo\nBaron Zemo\nBast\nBeast\nBeta Ray Bill\nBishop\nBlack Bolt\nBlack Cat\nBlack Knight\nBlack Panther\nBlack Swan\nBlack Widow\nBlade\nBlink\nBlob\nBlue Marvel\nBrood\nBucky Barnes\nBullseye\nCable\nCaiera\nCannonball\nCaptain America\nCaptain Marvel\nCarnage\nCloak\nColleen Wing\nColossus\nCorvus Glaive\nCosmo\nCrossbones\nCrystal\nCull Obsidian\nCyclops\nDagger\nDaredevil\nDarkhawk\nDazzler\nDeadpool\nDeath\nDeathlok\nDebrii\nDestroyer\nDevil Dinosaur\nDjinn\nDrDoom\nDoctor Octopus\nDoctor Strange\nDomino\nDracula\nDrax\nEbony Maw\nEcho\nElectro\nElektra\nElsa Bloodstone\nEnchantress\nFalcon\nFirestar\nForge\nGalactus\nGambit\nGamora\nGhost\nGhost Rider\nGhost-Spider\nGiganto\nGilgamesh\nGladiator\nGoose\nGrand Master\nGreen Goblin\nGroot\nHavok\nHawkeye\nHazmat\nHeimdall\nHela\nHellcow\nHercules\nHigh Evolutionary\nHit Monkey\nHobgoblin\nHope Summers\nHulk\nHuman Torch\nIceman\nInvisible Woman\nIron Fist\nIron Lad\nIron Man\nIronheart\nJane Foster\nJean Grey\nJeff The Baby Land Shark\nJessica Jones\nJubilee\nJuggernaut\nKa-Zar\nKang\nKillmonger\nKingpin\nKitty Pryde\nKlaw\nKnull\nKraven\nLady Deathstrike\nLady Sif\nLeader\nLeech\nLegion\nLizard\nLockjaw\nLoki\nLuke Cage\nMagik\nMagneto\nMakkari\nMantis\nMartyr\nMaximus\nMedusa\nMephisto\nMiek\nMiles Morales\nMirage\nMr Fantastic\nMrNegative\nMrSinister\nMisty Knight\nMockingbird\nMODOK\nMojo\nMonster\nMoon Girl\nMoon Knight\nMorbius\nMorph\nMs Marvel\nMultiple Man\nMysterio\nMystique\nNakia\nNamor\nNamora\nNebula\nNegasonic Teenage Warhead\nNightcrawler\nNimrod\nNinja\nNocturne\nNova\nOdin\nOmega Red\nOnslaught\nOrka\nPatriot\nPhastos\nPixie\nPolaris\nProfessor X\nProxima Midnight\nPsylocke\nPunisher\nQuake\nQuicksilver\nRaptor\nRed Guardian\nRed Hulk\nRed Skull\nRescue\nRhino\nRocket Raccoon\nRockslide\nRogue\nRonan\nSabretooth\nSage\nSandman\nSasquatch\nSauron\nScarlet Witch\nScorpion\nSebastian Shaw\nSelene\nSentinel\nSentry\nSera\nSersi\nShadow King\nShang-Chi\nShanna\nShe-Hulk\nShocker\nShuri\nSilk\nSilver Sable\nSilver Surfer\nSkaar\nSpectrum\nSpider-Ham\nSpider-Man\nSpider-Man 2099\nSpider-Woman\nSquirrel Girl\nStar-Lord\nStature\nStorm\nSunspot\nSuper-Skrull\nSupergiant\nSurtur\nSwarm\nSword Master\nTaskmaster\nThanos\nThe Collector\nLiving Tribunal\nThe Phoenix Force\nThe Thing\nThena\nThor\nTitania\nTyphoid Mary\nUatu\nUltron\nValentina\nValkyrie\nVenom\nViper\nVision\nWar Machine\nWarpath\nWasp\nWave\nWhite Queen\nWhite Tiger\nWhite Widow\nWolfsbane\nWolverine\nX-23\nYellowjacket\nYondu\nZabu\nZero\n";
        string[] names = namesString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
       /* string url = String.Empty;
        WebClient webClient = new WebClient();
        foreach (string name in names)
        {
            if (!name.Equals("Starter Card"))
            {
                
               string searchname = name.Replace(" ", "").Replace("-", "");
               Console.WriteLine(searchname +" downloaded");
              url = "https://static.marvelsnap.pro/cards/" + searchname + "-uncommon.webp";
              webClient.DownloadFile(new Uri(url), @"/Users/zedikejiani/Downloads/marvelimages/card/uncommon/"+name+".webp"); 
            
            }
        }
*/
       foreach (string name in names)
       {
           if (!name.Equals("Starter Card"))
           {

               string useablename = name.Replace(" ", "").Replace("-", "");
               MSCard temp = new MSCard
               {
                   id = 0,
                   name = useablename,
                   
               };
               await AddMsCard(temp);
               
               Console.WriteLine(useablename +" added");
               
           }
       }


       /*  webClient.DownloadFile(new Uri(url), @"/Users/zedikejiani/Downloads/marvelimages/art/"+"something_uncommon_.webp");
         */
      
     /*   HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        if (!response.StatusCode.ToString().Equals("NotFound"))
        {
            Console.WriteLine("Do something");
        }
        */
        return Ok();
    }

    [HttpGet("/marvel/{searchString}")]
    public async Task<ActionResult> GetHero(string searchString)
    {
      
        CharacterDataWrapper CharacterModel = await Marvel.GetCharacters(searchString);
        Character _character = CharacterModel.data.results.FirstOrDefault();
        if (searchString == null)
        {
            return BadRequest("searchString cannot be null");
        }

       
        if (_character == null || _character.description.IsNullOrEmpty())
        {
            string url = "https://www.marvel.com/characters/"+searchString.ToLower();
            WebClient client = new WebClient();
            string html = client.DownloadString(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Specify the tag name and class name you want to select
            string tagName = "div";
            string className = "masthead__copy";

            // Select nodes based on the specified tag name and class name
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes($"//{tagName}[contains(@class, '{className}')]");

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    Console.WriteLine(WebUtility.HtmlDecode(node.InnerText));
                    _character.description = WebUtility.HtmlDecode(node.InnerText);
                   
                }
            }
            else
            {
                Console.WriteLine("No nodes found.");
            }

        }
        
        return Ok(_character);

    }
    
    [HttpGet]
 
    public async Task<ActionResult<List<MSCard>>> GetAllMScards()
    {
        var artworks = await _context.MSCards.ToListAsync();
        return Ok(artworks);
    }
    
    [HttpGet("{id}")]
    
    public async Task<ActionResult<List<MSCard>>> GetMsCardById(int id)
    {
        var artwork = await _context.MSCards.FindAsync(id);
        if (artwork == null)
        { 
            return NotFound("Nothing here for the Emperor");
        }
        return Ok(artwork);
    }
    
    
    [HttpPost]
    public async Task<ActionResult> AddMsCard(MSCard msCard)
    {
       
            //ValueGeneratedOnAdd();
        
        try
        {
            _context.MSCards.Add(msCard);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        await _context.SaveChangesAsync();
       
        return Ok("Marvel Snap Card Added");
    }
   
    
    [HttpGet("/user")]
    public async Task<ActionResult<users>> GetUser(int id)
    {
        var user = await _context.users.FindAsync(id);

        if (user.Equals(null))
        {
            return NotFound("Nothing here for the Emperor");
        }

        //user.name = user.name;
        
       // await _context.SaveChangesAsync();
       
        
        return Ok(await _context.users.FindAsync(id));
    }
    
    [HttpPut("/user")]
    public async Task<ActionResult<users>> AddToCollection(int id, int cardid)
    { 
        var sessionexists = await _context.sessions.FirstOrDefaultAsync(u => u.userId == id);
        
        if (sessionexists != null)
        {
            Console.WriteLine("\nAdding to Collection...\n");
            Console.WriteLine("ID: "+id +" Card ID: "+ cardid);
     

  
            var user = await _context.users.FindAsync(id);

            if (user.Equals(null))
            {
                return NotFound("Nothing here for the Emperor");
            }

            user.cardcollection.Add(cardid);
        
            await _context.SaveChangesAsync();
       
        
            return Ok(await _context.users.FindAsync(id));
        }
        else
        {
            return Unauthorized("NOT YOU");
        }
       
    }
    
    
    [HttpPut]
    public async Task<ActionResult<List<MSCard>>> UpdateMSCard(MSCard msCard)
    {
        var artwork = await _context.MSCards.FindAsync(msCard.id);

        if (artwork.Equals(null))
        {
            return NotFound("Nothing here for the Emperor");
        }

        artwork.name = msCard.name;
        artwork.description = msCard.description;
        artwork.image = msCard.image;
        artwork.cardinfolink=msCard.cardinfolink;
        artwork.latitude = msCard.latitude;
        artwork.longitude = msCard.longitude;
        await _context.SaveChangesAsync();
       
        
        return Ok(await _context.MSCards.FindAsync(artwork.id));
    }
    
    
    
    
    [HttpGet("/user/collection")]
    public async Task<ActionResult<users>> GetColleciton(int id)
    {
        var user = await _context.users.FindAsync(id);
List<string> cardnames = new List<string>();
        if (user.Equals(null))
        {
            return NotFound("Nothing here for the Emperor");
        }
        foreach (var cardid in user.cardcollection)
        {
            var cardretrieved = await _context.MSCards.FindAsync(cardid);
            
            cardnames.Add(cardretrieved.name);

        }
       
        
        // await _context.SaveChangesAsync();
       
        
      return Ok(cardnames);
    
    }
}
