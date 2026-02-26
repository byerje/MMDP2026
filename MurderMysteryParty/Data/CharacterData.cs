using MurderMysteryParty.Models;

namespace MurderMysteryParty.Data
{
    public static class CharacterData
    {
        public static List<Character> GetCharacters()
        {
            return new List<Character>
            {
                new Character
                {
                    Id = 1,
                    Name = "Zetta Zarbo",
                    Occupation = "Silent Film Star",
                    Relationship = "Hollywood glamour queen visiting the speakeasy",
                    Background = "A glamorous silent-film star known for expressive performances, dramatic flair, and a larger-than-life public persona. She commands attention wherever she goes.",
                    PersonalityTraits = "Dramatic, attention-seeking, secretly insecure about talkies replacing silent films",
                    Goals = "To maintain her stardom in the changing entertainment industry",
                    Secrets = "Her career is failing and she's desperate for money",
                    Costume = "Long satin gown with feathered wrap, finger waves hairstyle, dark cupid's bow lipstick, smoky eyes",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Hershey Bar and say: 'Hershey, if Hal Sapone thinks he can bully talent into silence, drown him out. I refuse to be upstaged by a thug with a temper.'\n• Go to Kara Low and say: 'Kara, sweetheart—did Hal threaten your voice, or your freedom? I've got a feeling he's collecting souvenirs.'\n• Go to Daisy LaRue and say: 'Daisy, darling—keep those taps on the stage, not the hallway. If trouble starts, I want witnesses.'\n\nCONCEALED SECRETS:\n• Hal is sitting on a scandalous photo of you; he's hinted he'll 'deliver a note' later tonight.\n• You hid your contract backstage—if Hal finds it, he can ruin your next picture deal.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Hal will slip you a blackmail note with a smug grin.\n• Go to Hershey Bar and say: 'Between us, Hershey, Sapone's been squeezin' talent like it's sheet music he owns. So, let's let him have it.'\n• Go to Ray Stingray and say: 'Ray, darling—when you write your next bestseller, make sure the leading lady has cheekbones and a tragic past. I'm available for research.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was backstage tearing up a blackmail note when the shot rang out.\n• If asked, you can CORROBORATE: Kara Low / Daisy LaRue\n  • If asked about Kara Low, say exactly: 'Kara Low was backstage warming up when the booming noise filled the room.'\n  • If asked about Daisy LaRue, say exactly: 'Daisy LaRue was by the stage tapping away at the time of the deafening blast.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Officer Clyde 'Clipper' Mulligan\nTRUE STORY REVEAL:\nI was backstage tearing up the little blackmail note Hal slipped me—hands shaking, pride intact. Kara heard me muttering and told me to breathe. The bang made the tear go crooked; I still have the ripped pieces to prove it.\nFOLLOWED BY: Ruby 'Red' Callahan",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Officer Mulligan detains anyone, shriek 'MY CLOSE-UP!' and faint onto the nearest chair."
                },
                new Character
                {
                    Id = 2,
                    Name = "Hal Sapone",
                    Occupation = "Crime Boss (South Side Gang)",
                    Relationship = "Powerful underworld figure with territory disputes",
                    Background = "A powerful and intimidating figure in the city's underworld, accustomed to being obeyed and rarely challenged.",
                    PersonalityTraits = "Ruthless, commanding, surprisingly cultured",
                    Goals = "To eliminate his rivals and control all illegal activities in the city",
                    Secrets = "He's planning to have his rival Beanie O'Dannon eliminated tonight",
                    Costume = "Pinstripe suit with fedora and black tie, slicked back hair, fake cigar, pinky ring",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Zetta Zarbo and say: 'Zetta—smile for me. I've got a little note for you later… and it's not fan mail.'\n• Go to Tommy 'Four Guns' Beagle and say: 'Tommy, stay near the hallway door tonight. If I move to the back, you don't follow unless I whistle.'\n• Go to 'Handsome Sam' McWarthy and say: 'Pass a message along, Sam. Beanie's expandin' where he ain't invited. If he doesn't pull back, I'll start closin' doors.'\n\nCONCEALED SECRETS:\n• You already wrote Zetta's blackmail note. It reads: 'We both know what's in that photo I took. Sign the contract or else! -H'\n• You've been paying off a 'respectable doctor' for quiet favors, and it's starting to cost you leverage.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Give Zetta Zarbo a folded blackmail note with a smug grin. It reads: 'We both know what's in that photo I took. Sign the contract or else! -H'\n• Go to at Mona Crawfish and say: 'That dance marathon of yours? I'm buying it. I'll own it by Friday.'\n• Go to Kara Low and say: 'Sign my contract, or I crush your career. Simple.'\n• Go to Ruby 'Red' Callahan and say: 'Red, your till is light. I'll find the thief—even if it's you.'\n• Go to Tommy 'Four Guns' Beagle and say: 'Tommy—post up by the office door. Nobody slips into the storage hallway without me knowing.'\nSPECIAL: One of the hosts will quietly pull you aside with private instructions. Don't mention this to anyone.",
                    Round2BContent = "PART B – (INTENTIONALLY BLANK)",
                    Round3AMotiveReveal = "Hal Sapone is deceased and does not participate in the final reveal.",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nWhen Beanie yells, 'IT'S AN INSIDE JOB!' and when Tommy says 'RAT IN THE ROOM!', stand up and yell 'I'LL HAUNT ALL YOU DIRTY ROTTEN SCOUNDRELS!' and then drop dead on the floor."
                },
                new Character
                {
                    Id = 3,
                    Name = "Mona Crawfish",
                    Occupation = "Marathon Dancing Champion",
                    Relationship = "Local celebrity and party entertainment",
                    Background = "Legendary endurance dancer, tough and competitive, always pushing past limits.",
                    PersonalityTraits = "Competitive, determined, physically tough but emotionally vulnerable",
                    Goals = "To win enough prize money to support her sick mother",
                    Secrets = "She's been taking performance-enhancing stimulants to win competitions",
                    Costume = "Beaded flapper dress with short bob hairstyle, dance shoes, headband",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Hershey Bar and say: 'Hershey, keep that horn warmed up—if anything pops off, I want the whole room looking your direction.'\n• Go to Dr. Viola Thatch and say: 'Watch out, Doc! Sapone's been actin' like he's untouchable. I've seen plenty of 'untouchables' hit the floor when the pace picks up.'\n• Go to Chuck Limberger and say: 'Chuck, I heard Hal might be puttin' you outta business. If he squeezes you, he squeezes my circuit too.'\n\nCONCEALED SECRETS:\n• Hal demanded a cut of your dance marathon winnings; you're one threat away from snapping.\n• You overheard Hal mutter 'get the doctor' like it was routine—and that chilled you.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Tommy 'Four Guns' Beagle and say: 'I heard Hal joking that he would 'own' my next dance marathon. I could just kill him!'\n• Go to Jazzy Fringe and say: 'Between us, Jazzy, Sapone's been pushin' everyone past their limit tonight. That's when people stop playin' along.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was stretching by the side bar when the blast went off.\n• If asked, you can CORROBORATE: Hershey Bar / Haddie Drinx\n  • If asked about Hershey Bar, say exactly: 'I heard Hershey honk a sour sax note the instant the loud pop hit.'\n  • If asked about Haddie Drinx, say exactly: 'I saw Haddie at the bar with Haddie Drinx's hands full when the sharp crack echoed.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Jazzy Fringe\nTRUE STORY REVEAL:\nI was stretching by the side bar, saving my legs for the next dance marathon. When the bang hit, Jazzy shrieked and I toppled like a stack of pancakes—Haddie saw me topple. I've got stamina, not stealth.\nFOLLOWED BY: Kara Low",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Jazzy finger-guns anyone, do a frantic Charleston, bump two people, and blame BOTH for starting it."
                },
                new Character
                {
                    Id = 4,
                    Name = "Kara Low",
                    Occupation = "Nightclub Singer",
                    Relationship = "Star performer who knows everyone's secrets",
                    Background = "Polished singer with a disciplined voice who carefully watches the room.",
                    PersonalityTraits = "Observant, calculating, musically gifted",
                    Goals = "To gather enough information to blackmail her way to the top",
                    Secrets = "She's been recording private conversations for blackmail purposes",
                    Costume = "Sequined dress with long gloves, soft waves hairstyle, feathered headpiece, faux fur stole",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to 'Handsome Sam' McWarthy and say: 'Sam, darlin'—I might have some dirt on Hal, if you and your boss can make it worth my while.'\n• Go to Chuck Limberger and say: 'Chuck, you still got that plane of yours ready to lift on short notice? Funny thing—After singin' my last note, I might need a quick exit.'\n• Go to Marlie Maplin and say: 'Marlie—did Hal meddle with your picture deal too, or am I the only one he's trying to own?'\n\nCONCEALED SECRETS:\n• Hal tried to force you into an exclusive contract; you've been hiding the unsigned papers backstage.\n• You overheard a low, tense whisper behind the stage curtain: '…storage hallway' now.'",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Daisy LaRue and say: 'Hal hinted that he would crush my contract.'\n• Go to Dr. Viola Thatch and say: 'I heard low voices behind the curtain near the hall. Did you hear it too?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was backstage warming up my voice when the explosive sound tore through the club.\n• If asked, you can CORROBORATE: Jazzy Fringe / Zetta Zarbo\n  • If asked about Jazzy Fringe, say exactly: 'I know Jazzy Fringe jazzy was on the dance floor mid‐routine when the report echoed down the hallway.'\n  • If asked about Zetta Zarbo, say exactly: 'I know Zetta Zarbo zetta was backstage tearing a paper into bits when the gun sounded.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Mona Crawfish\nTRUE STORY REVEAL:\nI was backstage warming my voice, trying to hit a high note that could shatter glass. Zetta yelled at me to 'keep it down' seconds before the bang. If I'd been in that hallway, you'd have heard me coming.\nFOLLOWED BY: Professor Alistair Finch",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf the person yells out an EVEN number stand up and sing 'Eensy, Weensy Spider'."
                },
                new Character
                {
                    Id = 5,
                    Name = "Beanie O'Dannon",
                    Occupation = "Crime Boss (Northern Outfit)",
                    Relationship = "Hal Sapone's main rival",
                    Background = "Confident and calculating operator who prefers open confrontation.",
                    PersonalityTraits = "Bold, confrontational, strategic thinker",
                    Goals = "To destroy Hal Sapone's organization and take over his territory",
                    Secrets = "He's secretly working with federal agents to bring down other crime families",
                    Costume = "Dark 3-piece suit with slicked hair and severe part, cane or pocket watch",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to 'Handsome Sam' McWarthy and say: 'Sam—keep it public tonight. If I'm at the bar, you're at my shoulder, capisce?'\n• Go to Tommy 'Four Guns' Beagle and say: 'Tommy—tell your boss I don't sneak around. If Hal wants to talk, he can do it out in the open. I gotta protect myself and I don't trust that low-life.'\n• Go to Dr. Viola Thatch and say: 'Hey Doc, if Sapone ain't treatin' you right, come knockin' on my door for a new gig. I treat my people right, Doll.'\n\nCONCEALED SECRETS:\n• You planted a watcher to see who follows Hal when he slips toward the back.\n• Hal intercepted one of your supply runs; you're itching to retaliate—carefully.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Tommy 'Four Guns' Beagle and say: 'Hal baited me publicly about expanding his turf boundaries. No way! Tell him to stay away from my half of the city!'\n• Go to Wyleen Black and say: 'Print one word about me and you'll be chewing headlines through a straw.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was at the bar arguing loudly with Sam when the shot rang out.\n• If asked, you can CORROBORATE: Chuck Limberger / 'Handsome Sam' McWarthy\n  • If asked about Chuck Limberger, say exactly: 'I know Chuck Limberger chuck was hobbling by the office door after twisting his ankle when the pistol fired.'\n  • If asked about 'Handsome Sam' McWarthy, say exactly: 'I know 'Handsome Sam' McWarthy sam was by my side when we heard kablam.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Ruby 'Red' Callahan\nTRUE STORY REVEAL:\nI was leaning against the bar jawing with Sam, and the bang made me spill good whiskey—which is the real tragedy. The barkeep, the waitress, half the room saw it. I'd never commit a murder that wastes a drink.\nFOLLOWED BY: Dr. Viola Thatch",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Ruby shouts 'EVERYBODY FREEZE!', yell 'IT'S AN INSIDE JOB!' and tell Sam to kill everyone."
                },
                new Character
                {
                    Id = 6,
                    Name = "Haddie Drinx",
                    Occupation = "Waitress",
                    Relationship = "Hardworking employee who sees everything",
                    Background = "Fast-moving waitress who knows the rhythm of the club better than anyone.",
                    PersonalityTraits = "Observant, hardworking, protective of the other staff",
                    Goals = "To earn enough money to open her own restaurant",
                    Secrets = "She's been watering down drinks and pocketing the difference",
                    Costume = "Black dress with white apron, hair pulled back, carrying tray and order pad",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Ruby 'Red' Callahan and say: 'Red—if I'm hustling at the bar all night, you'd better keep the register honest. Hal's sniffing around.'\n• Go to Mona Crawfish and say: 'Mona—if you see me juggling a tray when trouble starts, shout 'Order up!' and pull eyes to the bar.'\n• Go to Harry Looper and say: 'Harry—if you're practicing in that hallway mirror again, at least do it where people can see you.'\n\nCONCEALED SECRETS:\n• You overheard Hal arguing in the storage hallway and caught the word 'career'—someone's being squeezed hard.\n• You saw some papers tucked backstage near Zetta's things; you kept one page as leverage. It looks like Zetta's contract with Hal.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Beanie O'Dannon and say: 'Here's the whisky you ordered.'\n• Go to Ruby 'Red' Callahan and say: 'I saw you slam the register shut when startled. Why so jumpy?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was at the main bar with a tray in my hands when the loud boom, like a gun shot.\n• If asked, you can CORROBORATE: Mona Crawfish / Ruby 'Red' Callahan\n  • If asked about Mona Crawfish, say exactly: 'I saw Mona stretching by the side bar when the gun exploded.'\n  • If asked about Ruby 'Red' Callahan, say exactly: 'I saw Red at the register—both hands in the drawer at the time the shot was fired.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: (First Speaker)\nTRUE STORY REVEAL:\nTruth is, I was working the main bar when that bang rang out—arms full of glasses. Ruby and Hershey saw me drop a whole tray in surprise. I've got secrets, sure— but not a free hand to pull a trigger.\nFOLLOWED BY: Daisy LaRue",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf anyone screams, drops, faints, or yells 'SHOT!', shriek 'NOT IN MY LOUNGE!' and drop to the ground. If someone else drops too, join them on the floor dramatically."
                },
                new Character
                {
                    Id = 7,
                    Name = "Lola Glass",
                    Occupation = "Waitress",
                    Relationship = "Veteran server with connections to regular patrons",
                    Background = "Keeps the drinks full and the questions light at the other end of the bar.",
                    PersonalityTraits = "Discreet, professional, surprisingly well-informed",
                    Goals = "To maintain her position and protect her regulars' secrets",
                    Secrets = "She's been passing information about customers to the police",
                    Costume = "Black dress with white apron, short waves hairstyle, carrying tray and order pad",
                    Round1Content = "LOLA GLASS - Round 1\n\nYou work the other end of the bar from Haddie, keeping drinks flowing and conversations light. Tonight feels different though - there's tension in the air and you can sense trouble brewing.\n\nYour Role: Keep observing the patrons and stay alert. Work closely with Haddie to keep service smooth, but watch for any suspicious behavior among the guests.\n\nSecret Objective: You've been keeping mental notes on regular customers for your own protection. Tonight, pay special attention to any private conversations or unusual meetings.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Beanie O'Dannon and say: 'Here's the whisky you ordered.'\n• Go to Ruby 'Red' Callahan and say: 'I saw you slam the register shut when startled. Why so jumpy?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was at the main bar with a tray in my hands when the loud boom, like a gun shot.\n• If asked, you can CORROBORATE: Mona Crawfish / Ruby 'Red' Callahan\n  • If asked about Mona Crawfish, say exactly: 'I saw Mona stretching by the side bar when the gun exploded.'\n  • If asked about Ruby 'Red' Callahan, say exactly: 'I saw Red at the register—both hands in the drawer at the time the shot was fired.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: (First Speaker)\nTRUE STORY REVEAL:\nTruth is, I was working the main bar when that bang rang out—arms full of glasses. Ruby and Hershey saw me drop a whole tray in surprise. I've got secrets, sure— but not a free hand to pull a trigger.\nFOLLOWED BY: Daisy LaRue",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf anyone screams, drops, faints, or yells 'SHOT!', shriek 'NOT IN MY LOUNGE!' and drop to the ground. If someone else drops too, join them on the floor dramatically."
                },
                new Character
                {
                    Id = 8,
                    Name = "Tommy \"Four Guns\" Beagle",
                    Occupation = "Enforcer",
                    Relationship = "Muscle for hire, loyal to whoever pays best",
                    Background = "Hard-edged, loyal right-hand man always on alert.",
                    PersonalityTraits = "Violent, loyal, simple but effective",
                    Goals = "To prove his worth and move up in the criminal hierarchy",
                    Secrets = "He's planning to eliminate his current boss and take over",
                    Costume = "Suspenders with rolled sleeves, slicked back hair, shoulder holster (prop), fake mustache",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Chuck Limberger and say: 'Chuck—if you're hauling crates tonight, keep them away from the storage hallway. I don't want any surprises.'\n• Go to 'Handsome Sam' McWarthy and say: 'Sam, you and your boys betta' stay out of the storage hallway area. That's Hal Sapone's territory.'\n• Go to Ruby 'Red' Callahan and say: 'Red, your till is light and Hal knows it! Some shady scoundrel's skimming your register—and He don't tolerate swindlers!'\n\nCONCEALED SECRETS:\n• You've seen Hal's payoff ledger—one name that keeps popping up is Dr. Viola Thatch along with Zetta Zarbo.\n• Hal hinted he might replace you after tonight; you're hunting for an exit plan, just in case.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Haddie Drinx and say exactly: 'Hal ordered me to stay posted where I can watch the hallway. If anyone asks, Haddie Drinx can say Tommy 'Four Guns' Beagle was stationed by the office door.'\n• Go to 'Handsome Sam' McWarthy and say angrily: 'I heard that Hal may be looking to replace me. Hal's a fink. I've been runnin' his racket longer than any other mug!'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was posted by the office door watching the hallway on Hal's orders at the time of the deafening blast. I guess someone coulda' snuck passed my watch since I get distracted sometimes.\n• If asked, you can CORROBORATE: 'Handsome Sam' McWarthy / Chuck Limberger\n  • If asked about 'Handsome Sam' McWarthy, say exactly: 'I know 'Handsome Sam' McWarthy sam was jawing with Beanie at the bar when I heard the shot.'\n  • If asked about Chuck Limberger, say exactly: 'I know Chuck Limberger chuck was hobbling around by the office door at the time the shot was fired.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Professor Alistair Finch\nTRUE STORY REVEAL:\nI was posted to watch the office door and storage hallway like Hal ordered, watching for trouble and counting footsteps. Chuck will tell you I teased him about his ankle right before the bang. If I'd left my post, Hal would've had my hide—ironically.\nFOLLOWED BY: 'Handsome Sam' McWarthy",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Finch's gadget 'beeps', finger-gun the ceiling twice and shout 'RAT IN THE ROOM!'"
                },
                new Character
                {
                    Id = 9,
                    Name = "Handsome Sam McWarthy",
                    Occupation = "Enforcer",
                    Relationship = "Charming muscle who uses charm before violence",
                    Background = "Smooth-talking charmer with dangerous confidence.",
                    PersonalityTraits = "Charismatic, dangerous, overconfident",
                    Goals = "To become a crime boss in his own right",
                    Secrets = "He's been embezzling money from his employer's collections",
                    Costume = "Tailored vest and tie, combed back hair, pocket comb, faux revolver",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Beanie O'Dannon and say: 'Boss, I'll keep it loud at the bar. No one can say we were 'sneaking' anywhere.'\n• Go to Wyleen Black and say: 'Wyleen—print what you like, but if you mention my name, make it flattering, or else!'\n• Go to Kara Low and say: 'Kara, sweetheart—keep singing, nice and loud. If the room stays noisy, nobody hears private business.'\n\nCONCEALED SECRETS:\n• You saw Hal slip an envelope into his jacket and tap the pocket like it was a weapon.\n• You spotted Dr. Thatch near the supply area earlier, looking far too composed for this crowd.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Beanie told you to keep Hal distracted. Go to Hal and ask about his business and plans for the future.\n• Go to Beanie O'Dannon and say: 'Hal looks rattled—like someone's cornered him and he's looking for a way out.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was at the bar jawing with Beanie when I heard the loud noise.\n• If asked, you can CORROBORATE: Beanie O'Dannon / Tommy 'Four Guns' Beagle\n  • If asked about Beanie O'Dannon, say exactly: 'I know Beanie O'Dannon beanie was at the bar yelling at Sam when the big bang occurred—loud as a parade.'\n  • If asked about Tommy 'Four Guns' Beagle, say exactly: 'I saw Tommy stationed near the office door when the blast went off.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Tommy 'Four Guns' Beagle\nTRUE STORY REVEAL:\nI was locked in a loud argument with Beanie at the bar, the kind where everyone hears every insult. Ruby and Haddie were close enough to wince. I don't do quiet hallway work; I make public problems public.\nFOLLOWED BY: Officer Clyde 'Clipper' Mulligan",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Tommy shouts 'RAT IN THE ROOM', slick your hair back and demand a silent stare-off with him. The first one to blink is guilty."
                },
                new Character
                {
                    Id = 10,
                    Name = "Hershey Bar",
                    Occupation = "Baseball Player & Jazz Musician",
                    Relationship = "Multi-talented performer and local celebrity",
                    Background = "Confident performer used to commanding attention.",
                    PersonalityTraits = "Charismatic, athletic, musically gifted",
                    Goals = "To make it big in either baseball or music",
                    Secrets = "He's been throwing baseball games for gambling money",
                    Costume = "Baseball jersey or jazz suit, loose curls hairstyle, carrying toy bat or saxophone",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Professor Alistair Finch and say: 'Professor, Sapone's got a way of sourin' every room he walks into. You're not the only one who's had enough. If he keeps pushing, he might be pushing up daisies.'\n• Go to Jazzy Fringe and say: 'Jazzy—the dance floor is all yours tonight. If anything gets weird, I'll blast a note so sour it clears the room.'\n• Go to Haddie Drinx and say: 'Haddie, you keep those drinks flowing, I'll keep the music loud—nobody talks murder over jazz.'\n\nCONCEALED SECRETS:\n• Hal tried to use your gigs to launder cash; you refused and he didn't take it kindly.\n• You saw Chuck fussing with a crate earlier and it gave you a bad feeling.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Harry Looper and say: 'Harry, Hal tried to buy my silence. If he tries that with you, don't take the bait.'\n• Go to Mona Crawfish and say: 'If things go badly tonight, I saw you stretching and you saw me tuning up my instrument, right?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was tuning my sax by the dance floor when I heard the crack.\n• If asked, you can CORROBORATE: Ruby 'Red' Callahan / Mona Crawfish\n  • If asked about Ruby 'Red' Callahan, say exactly: 'I saw Red at the register—both hands in the drawer—when the sharp crack echoed.'\n  • If asked about Mona Crawfish, say exactly: 'I saw Mona Crawfish stretching by the bar at the time of the loud pop.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Daisy LaRue\nTRUE STORY REVEAL:\nI was tuning my sax near the dance floor, chasing a note that refused to behave. When the bang hit, I hit a sour honk that made half the room wince—Red and Mona heard it. I've played some rough gigs, but I didn't play Hal.\nFOLLOWED BY: Chuck Limberger",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Daisy shouts OR an accusation flies, blast an imaginary sax note, then point at someone and loudly declare they have terrible rhythm."
                },
                new Character
                {
                    Id = 11,
                    Name = "Wyleen Black",
                    Occupation = "Tabloid Reporter",
                    Relationship = "Investigative journalist always looking for the next big story",
                    Background = "Relentless reporter always chasing the next story.",
                    PersonalityTraits = "Persistent, curious, fearless in pursuit of truth",
                    Goals = "To uncover the biggest scandal of the decade",
                    Secrets = "She's actually working undercover for federal law enforcement",
                    Costume = "Pencil skirt with blouse and trench coat, short curl bob, carrying notepad and camera",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Officer Clyde 'Clipper' Mulligan and say: 'Officer—off the record, how many badges are on Sapone's payroll?'\n• Go to Ray Stingray and say: 'Ray—give me one juicy headline about Hal Sapone for tomorrow's paper. What do you know?'\n• Go to Zetta Zarbo and say: 'Zetta—if Sapone's squeezing you, blink once for 'no' and twice for 'yes, make it known and I'll publish it.''\n\nCONCEALED SECRETS:\n• You snapped a photo of Hal speaking privately with a 'respectable doctor'—it could ruin careers.\n• You learned Hal plans to pass a blackmail note tonight; you're trying to find to whom.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Hal Sapone and say: 'Hal, you threatened my press pass and my kneecaps, but I've got photo proof of you that could ruin careers!'\n• You notice Mulligan scanning the room like a hawk. Go to Officer Clyde 'Clipper' Mulligan and say: 'Clipper, I noticed Hal talking with the good doctor. Who is bribing whom?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was at the entrance grilling Mulligan when the explosive sound tore through the club.\n• If asked, you can CORROBORATE: Professor Alistair Finch / Officer Clyde 'Clipper' Mulligan\n  • If asked about Professor Alistair Finch, say exactly: 'I know Professor Alistair Finch finch was fussing with that buzzing gadget in the corner when I heard the gun blast.'\n  • If asked about Officer Clyde 'Clipper' Mulligan, say exactly: 'I know Officer Clyde 'Clipper' Mulligan i was next to Mulligan near the entrance area when the shot was heard.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Ray Stingray\nTRUE STORY REVEAL:\nI was grilling Officer Mulligan near the entrance about who's been bribing whom. When the bang sounded, he ducked and I nearly swallowed my pencil—he'll confirm it, begrudgingly. I wanted Hal's headline, not his heartbeat.\nFOLLOWED BY: Harry Looper",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Ray shouts 'PLOT TWIST', yell 'I'VE GOT THE SCOOP!' and write a new headline in your invisible notebook."
                },
                new Character
                {
                    Id = 12,
                    Name = "Harry Looper",
                    Occupation = "Silent Film Actor",
                    Relationship = "Fellow performer and rival to Zetta Zarbo",
                    Background = "Over-dramatic actor who treats life like a movie scene.",
                    PersonalityTraits = "Theatrical, narcissistic, surprisingly insightful about human nature",
                    Goals = "To transition successfully to talking pictures",
                    Secrets = "He's been sabotaging other actors' careers to advance his own",
                    Costume = "Tuxedo or film-star attire, slicked back hair with curl, carrying fake award prop",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Marlie Maplin and say: 'Marlie—if you hear any juicy stories, tell me first. I don't want rumors starting without me.'\n• Go to Mona Crawfish and say: 'You ever notice, Mona, how Hal leans hardest on the people who know how to last the longest? He's been testin' my limits, too.'\n• Go to Beanie O'Dannon and say: 'Beanie, pal—if you see me at the hallway mirror later, that's acting, not sneaking.'\n\nCONCEALED SECRETS:\n• You're desperate for a comeback and you'd sell a scandal to fund a new picture.\n• You keep a prop pistol for auditions. It looks real enough to cause panic if seen.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Chuck Limberger and say: 'Keep an eye on Marlie Maplin, she is acting suspicious! Hal's using some dirt to keep Marlie in line. He owns her career.'\n• Go to Marlie Maplin and say: 'Hal called me 'replaceable' and laughed. He's got some nerve!'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was by the hallway mirror rehearsing a monologue when the gun fired.\n• If asked, you can CORROBORATE: Dr. Viola Thatch\n  • If asked about Dr. Viola Thatch, say exactly: 'I saw the lady doctor moving with purpose right around the time of the loud bang.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Wyleen Black\nTRUE STORY REVEAL:\nI was rehearsing a dramatic monologue at the mirror like a proper silent-film star. Beanie mocked me, Sam snickered, and then—bang—my audience got real quiet. I'm guilty of overacting, not murder.\nFOLLOWED BY: Jazzy Fringe",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Wyleen shouts, 'I'VE GOT THE SCOOP!', perform a dramatic death scene. Then pop up and declare 'I AM THE GREATEST ACTOR EVER!'."
                },
                new Character
                {
                    Id = 13,
                    Name = "Jazzy Fringe",
                    Occupation = "Flapper & Singer",
                    Relationship = "Young performer trying to make her mark",
                    Background = "Energetic flapper known for bold routines and flair.",
                    PersonalityTraits = "Energetic, bold, secretly ambitious",
                    Goals = "To become the most famous entertainer in the city",
                    Secrets = "She's been stealing other performers' routines and songs",
                    Costume = "Fringe flapper dress, short bob hairstyle, bold eye makeup and red lips",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Ray Stingray and say: 'Ray, Darlin'. Since you're writin' the truth—Hal's trying to turn me into his 'private performer'. I'd rather sing for the crowd than be on his payroll.'\n• Go to Kara Low and say: 'Kara—if Hal corners you backstage, you cough twice and I'll bring the whole dance floor over.'\n• Go to Wyleen Black and say: 'Wyleen, hon, Careful with that pencil, Wyleen—this joint's got enough drama without you inventing more.'\n\nCONCEALED SECRETS:\n• Hal's boys have been harassing you; you swiped a spare key to the backstage curtain area for safety.\n• You saw someone watching the hallway like it was the main event.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Daisy LaRue and say: 'Hal heckled my act.' <sob> 'I could just stab his throat out!'\n• Go to Harry Looper and say: 'Between us, Harry, this place is jumpy tonight—and it's Sapone's fault. Men like him forget performers remember who made them miserable.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was on the dance floor mid‐routine when the booming noise filled the room.\n• If asked, you can CORROBORATE: Daisy LaRue / Kara Low\n  • If asked about Daisy LaRue, say exactly: 'I know Daisy was by the stage tapping away when we all heard the loud noise.'\n  • If asked about Kara Low, say exactly: 'I know Kara Low kara was backstage warming up when plugged my ears.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Harry Looper\nTRUE STORY REVEAL:\nI was mid-routine by the dance floor, fringe flying, pride intact— until the bang made me squeal like a teapot. Daisy and Kara were right there near me. I cause scenes on stage, not in hallways.\nFOLLOWED BY: Mona Crawfish",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nWhen anyone 'dies' or drops to the floor, shout 'JAZZ ATTACK!' finger-gun two people, then freeze in a 'Charlie's Angels' pose."
                },
                new Character
                {
                    Id = 14,
                    Name = "Chuck Limberger",
                    Occupation = "American Pilot",
                    Relationship = "Adventurous pilot who smuggles for the speakeasy",
                    Background = "Adventurous pilot with restless energy.",
                    PersonalityTraits = "Adventurous, restless, fearless",
                    Goals = "To make enough money smuggling to buy his own airline",
                    Secrets = "He's been secretly flying for federal agents, gathering intelligence",
                    Costume = "Leather flight jacket with scarf, disheveled hair, aviator goggles",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Dr. Viola Thatch and say: 'Doc, you gotta help me out. What can I do about my bum ankle?'\n• Go to Professor Alistair Finch and say: 'Professor—if your gadget sparks again, warn me. I'm already flammable.'\n• Go to Ruby 'Red' Callahan and say: 'Red—if a crate shows up with my name on it, you didn't see it. Understand?'\n\nCONCEALED SECRETS:\n• You're tied to illegal deliveries for Hal; you're terrified that the wrong crate might end up in the wrong hands.\n• Your ankle's already sore—you want to stay near the office door, in case trouble erupts you'll have a place to slip out and hide.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Professor Alistair Finch and say: 'Hal Sapone hinted that he knew about some illegal deliveries that he thinks I've made. Can you believe it? I'd never do anything like that!'\n• Limp over to Tommy 'Four Guns' Beagle and say: 'I twisted my ankle! What more bad thing could happen tonight?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was by the side door nursing a twisted ankle when I heard the shot.\n• If asked, you can CORROBORATE: Tommy 'Four Guns' Beagle / Beanie O'Dannon\n  • If asked about Tommy 'Four Guns' Beagle, say exactly: 'I saw Four Guns at the office door when the blast went off.'\n  • If asked about Beanie O'Dannon, say exactly: 'I know Beanie O'Dannon beanie was yelling at Sam when the shot rang out—loud as a parade.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Hershey Bar\nTRUE STORY REVEAL:\nI was near the side door moving an empty crate out, and I turned my ankle on the step—loud enough to make Tommy laugh at me. When the bang echoed, I was mid-curse, nowhere near that hallway.\nFOLLOWED BY: Marlie Maplin",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Hershey makes noise, spin with airplane arms, 'crash land' beside someone, and accuse them of sabotaging your flight."
                },
                new Character
                {
                    Id = 15,
                    Name = "Marlie Maplin",
                    Occupation = "Silent Film Star",
                    Relationship = "Rising star and potential threat to established actors",
                    Background = "Quiet screen sweetheart with sharp awareness.",
                    PersonalityTraits = "Observant, quietly intelligent, deceptively innocent",
                    Goals = "To build a lasting career that survives the transition to talkies",
                    Secrets = "She's been blackmailing studio executives with compromising photos",
                    Costume = "Satin dress with pearls, wave-set curls, carrying cigarette holder (prop)",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Dr. Viola Thatch and say: 'Doctor—if I vanish to fix my face later, it's vanity, darlin', pure glitterin' vanity! Certainly not anything dreary like villainy!'\n• Go to Zetta Zarbo and say: 'Zetta—Sapone's been muttering names. If mine comes up, you tell me fast!'\n• Go to 'Handsome Sam' McWarthy and say: 'Tell Beanie, I've been silent my whole film career, but if tonight goes sideways, then I will find my voice!'\n\nCONCEALED SECRETS:\n• Hal threatened to sabotage your next picture unless you 'played nice' at his private meeting.\n• You saw Dr. Thatch slip toward the storage hallway and it struck you as oddly purposeful.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Chuck Limberger and say: 'Keep an eye on Marlie Maplin, she is acting suspicious! Hal's using some dirt to keep Marlie in line. He owns her career.'\n• Go to Marlie Maplin and say: 'Hal called me 'replaceable' and laughed. He's got some nerve!'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was by the hallway mirror rehearsing a monologue when the gun fired.\n• If asked, you can CORROBORATE: Dr. Viola Thatch\n  • If asked about Dr. Viola Thatch, say exactly: 'I saw the lady doctor moving with purpose right around the time of the loud bang.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Chuck Limberger\nTRUE STORY REVEAL:\nI was in the ladies' room fixing my face like it was a full-time job. Harry was fussing at the hallway mirror at the time of the murder; he can tell you I never left the bathroom. My career may be dramatic, but my alibi isn't.\nFOLLOWED BY: Ray Stingray",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Chuck crashes OR anyone hits the floor, mime silent-film panic, like you are stuck in a box and any other mime behavior."
                },
                new Character
                {
                    Id = 16,
                    Name = "Ray Stingray",
                    Occupation = "Novelist",
                    Relationship = "Writer researching criminal underworld for his next book",
                    Background = "Observant mystery writer always taking notes.",
                    PersonalityTraits = "Intellectual, observant, secretly ruthless",
                    Goals = "To write the definitive crime novel based on real events",
                    Secrets = "He's been planning the perfect murder for his book and considering trying it in real life",
                    Costume = "Modest 1920s outfit with neat hair, carrying glasses and notebook",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• When Wyleen Black asks you for a headline about Hal say: 'Wyleen—You'll have to read my book. But I can say that I definitely have the inside scoop. His number is up!'\n• Go to Professor Alistair Finch and say: 'Professor—your cipher machine is a perfect safe cracker. Don't let Hal get a hold of it.'\n• Go to Officer Clyde 'Clipper' Mulligan and say: 'Officer—tell me, purely for research, what would happen if someone was murdered tonight?'\n\nCONCEALED SECRETS:\n• Your notebook contains real names tied to Hal's operation—if he sees it, you're finished.\n• You've been recording conversations for 'authenticity' (or possibly blackmail). Your notes place people at key moments in suspicious locations.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Hershey Bar and say: 'I know you want this corruption story out more than anyone—me too. You help expose Hal Sapone and I'll give you some choice quotes!'\n• Go to Wyleen Black and say: 'Between you and me, Wyleen—Hal's got several dirty deals that would make great headlines. You got any juicy stories for me?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was by the office jotting down quotes when the explosive sound shook the building.\n• If asked, you can CORROBORATE: Professor Alistair Finch\n  • If asked about Professor Alistair Finch, say exactly: 'I know Professor Alistair Finch finch was near his contraption when the trigger sounded.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Marlie Maplin\nTRUE STORY REVEAL:\nI was seated with my notebook near the entrance, scribbling a chapter when the villain gets what's coming. The bang startled me so badly I blotted ink across the page—I showed Wyleen and she called it 'evidence.' I write murders; I don't commit them.\nFOLLOWED BY: Wyleen Black",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Marlie acts like a mime OR someone yells 'WHO DID IT', announce 'PLOT TWIST!' and point at two different people as co-conspirators and yell 'YOU and YOU!'."
                },
                new Character
                {
                    Id = 17,
                    Name = "Ruby \"Red\" Callahan",
                    Occupation = "Bootlegger",
                    Relationship = "Independent supplier competing with the major crime families",
                    Background = "Sharp-tongued speakeasy owner, fiercely protective.",
                    PersonalityTraits = "Tough, independent, fiercely protective of her territory",
                    Goals = "To build her own criminal empire without being absorbed by the big gangs",
                    Secrets = "She's been poisoning the competition's alcohol supplies",
                    Costume = "Red flapper dress with Marcel waves hairstyle, carrying fake liquor bottle and ledger",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Beanie O'Dannon and say: 'Beanie, I respect your operation. In my house we keep things tidy. No heat, no noise, no headaches.'\n• Go to Hershey Bar and say: 'Hershey—keep the music up. Loud jazz keeps quiet threats from sticking.'\n• Go to Hal Sapone and say: 'Hal, sugar, this is my lounge. You want a cut? You ask me like a gentleman. Don't beat around the bush with threats like a cheap palooka!'\n\nCONCEALED SECRETS:\n• Your register is short, and Hal noticed. If he has to 'help' you find the thief, you're done for.\n• You keep an emergency firearm under the bar—someone else knows where it is, but you're not sure who.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Marlie Maplin and say: 'I'll put in a good word for you if you help me with a little headache I'm having...Hal Sapone is causing me troubles!'\n• Go to Dr. Viola Thatch and say: 'Doctor, I need to know—if something happens to someone—would he suffer?'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was behind the bar wiping down glasses when the gunshot's boom echoed through the room.\n• If asked, you can CORROBORATE: Mona Crawfish\n  • If asked about Mona Crawfish, say exactly: 'I saw crazy Mona by the side bar when the deadly shot rang out.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Zetta Zarbo\nTRUE STORY REVEAL:\nI was at the bar register with both hands in the drawer, counting cash and keeping an eye on the clientele. When the bang sounded, I slammed it shut so hard I strained my wrist—Haddie was near and heard me yelp. If I wanted Hal gone, I'd have done it a heap quieter.\nFOLLOWED BY: Beanie O'Dannon",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Zetta faints OR Hal's ghost speaks, shout 'EVERYBODY FREEZE!' and finger-gun the floor, declaring martial law."
                },
                new Character
                {
                    Id = 18,
                    Name = "Prof. Alistair Finch",
                    Occupation = "Inventor",
                    Relationship = "Eccentric genius who creates gadgets for criminal enterprises",
                    Background = "Eccentric inventor obsessed with puzzles and codes.",
                    PersonalityTraits = "Brilliant, eccentric, socially awkward",
                    Goals = "To perfect his inventions and gain recognition for his genius",
                    Secrets = "He's been creating deadly devices that he's planning to test on real people",
                    Costume = "Tweed suit with bow tie, messy hair, carrying blueprints and gadget props",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Mona Crawfish and say: 'Mona, I heard Hal's putting pressure on you. In times like these, it makes sense if we birds of a feather stick together.'\n• Go to Wyleen Black and say: 'Wyleen—if you run a piece in your column about my invention, make sure to spell my name right! Also, keep Hal away from it.'\n• Go to Hal Sapone and say: 'Mr. Sapone, my device is for puzzles, not safe crackin'. Understood?'\n\nCONCEALED SECRETS:\n• Your cipher gadget occasionally sparks, but you are working on perfecting it.\n• Hal offered you money for your 'uncrackable code maker.' You refused—and he doesn't like refusals.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Ray Stingray and say: 'Ray, there's been too much chatter about my device tonight. Hal keeps circling back to the encryption possibilities.'\n• Go to Chuck Limberger and say: 'My gadget is sparking tonight—it's probably fine, but if anything happens, I was just testing the wiring.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was by my encryption device adjusting the mechanisms when the gunshot boomed.\n• If asked, you can CORROBORATE: Ray Stingray / Officer Clyde 'Clipper' Mulligan\n  • If asked about Ray Stingray, say exactly: 'Ray Stingray was near the office jotting notes when the shot fired.'\n  • If asked about Officer Clyde 'Clipper' Mulligan, say exactly: 'Officer Mulligan was near the entrance when the explosive noise echoed.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Kara Low\nTRUE STORY REVEAL:\nI was tinkering with my cipher contraption near the entrance, the one Hal wanted far too badly. When the bang happened, the device sparked and singed my sleeve—Ruby noticed and threatened to invoice me if I burned the place to ashes. I'm guilty of gadgets, not gunplay.\nFOLLOWED BY: Tommy 'Four Guns' Beagle",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Kara points at anyone, whip out your imaginary lie-detector and announce 'BEEPING MEANS GUILTY!' Walk around the room and scan wildly making random loud Beeping noises."
                },
                new Character
                {
                    Id = 19,
                    Name = "Daisy LaRue",
                    Occupation = "Chorus Girl",
                    Relationship = "Former Broadway performer seeking new opportunities",
                    Background = "Energetic former Broadway dancer seeking fame.",
                    PersonalityTraits = "Ambitious, energetic, desperate for stardom",
                    Goals = "To become a star by any means necessary",
                    Secrets = "She's been blackmailing theater producers and wealthy patrons",
                    Costume = "Sparkling feathered dress with finger waves hairstyle, glittery eye makeup and bold blush",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Jazzy Fringe and say: 'Jazzy—check out my new dance moves later. Meet me by the stage and I'll give you the razzle-dazzle!'\n• Go to Kara Low and say: 'Kara—if Hal gives you the squeeze, tell him he's gotta deal with me.'\n• Go to Harry Looper and say: 'Harry, Hal's thrown a wrench in both our careers. I'm about fed up with his back-stage meddling. You and me outta do somethin' about it!'\n\nCONCEALED SECRETS:\n• Hal once canceled your show when you rejected him; you still want payback.\n• You're staging a little practice routine near the stage later—perfect for being seen.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Mona Crawfish and say: 'I think Chuck Limberger is a dirty liar! He's been spreading rumors about Uncle, saying my Uncle is corrupt!'\n• Go to Hershey Bar and say: 'This place might make a girl nervous! Would you play a brave tune for the girls tonight? To help keep us calm!'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was near the stage tapping a rhythm to the music when the gunshot boomed.\n• If asked, you can CORROBORATE: Hershey Bar / Jazzy Fringe\n  • If asked about Hershey Bar, say exactly: 'I know Hershey Bar hershey was tuning up his sax when the shot thundered.'\n  • If asked about Jazzy Fringe, say exactly: 'I know Jazzy Fringe jazzy was dancing on the floor when the shot rang out.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Haddie Drinx\nTRUE STORY REVEAL:\nI was up by the stage practicing a soft-shoe routine, trying to impress anyone with a pulse. Jazzy and Hershey told me to quit tapping on the beat right before the bang. I may be desperate for the spotlight, but murder ain't my kind of show.\nFOLLOWED BY: Hershey Bar",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Haddie drops to the ground OR anyone falls, leap up shouting 'EMERGENCY INTERMISSION!' Strike a pose and accuse the nearest person of ruining your big moment."
                },
                new Character
                {
                    Id = 20,
                    Name = "Officer Clyde Mulligan",
                    Occupation = "Prohibition Agent",
                    Relationship = "Federal agent investigating the speakeasy operation",
                    Background = "Commanding lawman with a watchful eye.",
                    PersonalityTraits = "Authoritative, observant, morally conflicted",
                    Goals = "To enforce prohibition laws while navigating corruption",
                    Secrets = "He's been taking bribes from multiple criminal organizations",
                    Costume = "Trench coat with fedora, neat parted hair, carrying badge and billy club (prop)",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Haddie Drinx and say: 'Water down my drink tonight, Sweetie. As far as anyone else knows I'm 'off duty'—but I'd like to keep my wits sharp.'\n• Go to Ruby 'Red' Callahan and say: 'Red, if anything pops off, nobody leaves. Not to the alley, not out the entrance, nowhere.'\n• Go to Daisy LaRue and say: 'If any of these filthy mugs give you any trouble, Miss Daisy, tip me the nod. I make sure they remember their manners.'\n\nCONCEALED SECRETS:\n• You suspect someone here is carrying a small-caliber pistol, but you don't know who yet.\n• You have a crush on Daisy LaRue and Hal's talking like he owns her.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Professor Alistair Finch and say: 'Professor, I wouldn't stand near that machine of yours if I were you! There's been a lot of threats against various people tonight!'\n• Go to Wyleen Black and say: 'I'm not supposed to tell you this, but Hal's been making threats, and somebody's got to arrest him!'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was near the entrance questioning Wyleen when the gunshot blast erupted.\n• If asked, you can CORROBORATE: Wyleen Black\n  • If asked about Wyleen Black, say exactly: 'I know Wyleen Black wyleen was at the entrance when the gunshot blasted.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: 'Handsome Sam' McWarthy\nTRUE STORY REVEAL:\nI was near the entrance keeping an eye on the room—habit, not hobby. When the bang hit, I shouted 'Down!' and half the bar laughed at me after the panic passed. Wyleen was right there, taking notes like it was a sporting match.\nFOLLOWED BY: Zetta Zarbo",
                    Round3BChaoticEnding = "CHAOS TRIGGER:\nIf Sam starts a stare-off, blow a pretend whistle yelling 'CODE 29!' and detain someone for a slow 10-count, like a staggering boxer."
                },
                new Character
                {
                    Id = 21,
                    Name = "Dr. Viola Thatch",
                    Occupation = "Society Surgeon",
                    Relationship = "Respected doctor with connections to criminal underworld",
                    Background = "A calm, respected doctor accustomed to secrets. She maintains her professional reputation while being forced to provide medical services to the criminal element.",
                    PersonalityTraits = "Professional, discrete, morally conflicted, composed under pressure",
                    Goals = "To maintain her medical practice and reputation while extricating herself from criminal entanglements",
                    Secrets = "She's been providing illegal medical services to criminals and is looking for a way out",
                    Costume = "Elegant dress with gloves, hair in updo with waves, stethoscope, medical bag",
                    Round1Content = "INTERACTIONS & REVEAL CLUES:\n• Go to Hal Sapone and say: 'Mr. Sapone—if you need me for 'business,' you ask politely, in public.'\n• Go to Ruby 'Red' Callahan and say: 'Red, dear—Word on the street is that you've got a hidden 'fire cracker'. I need to know where it is, in case things get dicey around here.'\n• Go to Harry Looper and say: 'Mr. Looper—please don't practice dying in the hallway. It sets a dreadful precedent.'\n\nCONCEALED SECRETS:\n• Hal has demanded 'medical favors' for his men. You want out, but you're trapped.\n• You keep a compact medical bag hidden in the storage hallway; if anyone sees it, they'll assume the worst.",
                    Round2AContent = "PART A – PRE-MURDER:\n• Go to Hal Sapone and say: 'I'm done with your monkey business, pal. I'm cuttin' loose.'\n• Go to Kara Low and say: 'I saw Hal head toward the Hallway as if expecting someone.'\n• When Professor Alistair Finch comes to you, answer him with this: 'Refusing Sapone is never just a disagreement, Professor. I know for a fact that he doesn't forgive refusal.'",
                    Round2BContent = "PART B – POST-MURDER:\n• Your one-sentence alibi: I was 'checking supplies' at the moment when I heard the gun shot. I fix people, I don't break them!\n• If asked, you can CORROBORATE: Marlie Maplin\n  • If asked about Marlie Maplin, say exactly: 'I know Marlie Maplin marlie was in the ladies' room fussing with makeup and such when the gun fired.'",
                    Round3AMotiveReveal = "FOLLOW AFTER: Beanie O'Dannon\nTRUE STORY REVEAL:\nAll right—curtain call. I did it. Hal had me trapped, forcing 'favors' for his men and threatening to expose me the moment I resisted. When he slipped into that hallway to corner me again, I chose my career—and my freedom—over his life. One shot, quick and clean— and then I walked back into the music like nothing happened.",
                    Round3BChaoticEnding = "FINAL IGNITION: After confessing, point to any player and say: 'Pick a number between 1 and 10. Shout it out loud!'\nIf the number is Even = you shoot them (finger-gun).\nIf the number is Odd = yell, 'I CAN'T GO TO JAIL!' and shoot yourself in the head and fall to the floor."
                }
            };
        }
    }
}