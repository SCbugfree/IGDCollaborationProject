//This is the file storing dialogues in Scene6: Coffee Shop
// !Narrator @Player #Amelia/Daughter, %Jade/Mommy 1, ^: Mommy 2, &: NPC/No image
VAR Symbol = ""
VAR Response = ""
!The inside of the coffee shop is incredibly warm and inviting. Vinyl records line the walls and patrons lounge around on well-worn-in couches. Some cool tunes spin on a record player next to a little stage. #Narrator

$Welcome to Cafe Fork, guys! I’m Madi. How’s it going? #Madi

%What’s with the name? #Amelia

&Oh it’s um… kinda dumb. #Madi

%It gets mentioned in this poem I like, and I thought it was a good idea at the time, and I suppose now it’s still a good idea because like, the business is still running? #Madi

%But people ask me that question all the time and I give them this same answer every time and now I’m standing here rambling and I’m sure we’re all getting more and more uncomfortable the more I keep talking but man we’re in it now and I can’t stop. #Madi

%… #Amelia

%So what’ll it be? #Madi

!I scan the chalkboard menu and am immediately overwhelmed. #Narrator

%I’ll have a… #MommyClone

-> COF_Choice

== COF_Choice ==
* [Godspeed You!] 
    ~ Symbol = "$"
    ~ Response = "A classic!"
-> CONTINUE

* [Iced Teagan and Sara]
  ~ Symbol = "¥"
  ~ Response = "Alright."
-> CONTINUE

* [Chai Antwood] 
 ~ Symbol = "%"
  ~ Response = "Sounds good!"
-> CONTINUE



== CONTINUE ==
{Symbol}{Response} #Madi
%Coming right up! Do you want that in Small, Medium, or Biggie Smalls? #Madi

%Uh… medium… #MommyClone

%Wait, is Biggie Smalls big or small? #Amelia

¥Uh… #Madi

%I should change that, shouldn’t I? #Madi

!Madi sets to making our drinks and Amelia and I take a seat on one of the couches. #Narrator

%What’s her deal? #MommyClone

%Let the woman make her puns. They’re cooler bands than you listen to, anyways. #Amelia

%Hey. #MommyClone

%Ska was cool once. #MommyClone

!This couch is actually pretty comfy. Maybe not comfier than our couch, but it’s alright. Good lumbar support. You sink right into it. #Narrator

!Amelia nudges me. #Narrator

%This place is right next to our house and that lady seems not only cool but also just as uncomfortable with talking to other people as you are. #Amelia

%You should totally be friends with her. #Amelia

%Uh… I don’t know… #MommyClone

%C’mon, what’d we say about meeting new people? #Amelia

%I can’t meet new people if I always stay inside and also don’t go outside and also don’t talk to people. #MommyClone

%See? We’re making progress. #Amelia

!Madi sets our drinks down at our table and I immediately take a sip. #Narrator

%Hi! We’re new in the neighborhood! I’m Amelia and this is my Mom! #Amelia

$Oh right on! Pleased to meet you both! #Madi

%Let me introduce you to my daughter. You two might get along. #Madi

!Madi turns toward the employee only section. #Narrator

%CAMILLA! COME HERE! #Madi

!A young girl with green overalls walks out of the employee only section and towards our table. #Narrator

%This is my daughter, Camilla. #Madi

!Camilla smiles and waves. #Narrator

%Hi! I'm Camilla. #Camilla

%I'm Amelia. Nice to meet you, Camilla. #Amelia

%I have to go do my homework, but it was nice to meet you. #Camilla

!Camilla runs back to the employee section. #Narrator

%You know what? Lemme get your guys’ opinion on something. #Madi

!Madi goes into the back and comes out with a fresh plate of something that smells amazing. #Narrator

%I’m working on a new banana bread recipe and I need help coming up with a name for it. #Madi

%Well, I think we’re gonna have to taste test it first so we can uh… get the full flavor profile of… you know, and really appreciate the flavor sensations of… #MommyClone

!Amelia nods vigorously. She knows this game. #Narrator

%Yeah, we need to give that ‘nana bread a taste if you want us doing free creative labor, I think that would be commensurate with… uh… #Amelia

!I’ve taught her well. We have trained for this day. #Narrator

%I was just gonna give you guys free banana bread anyway. #Madi

%Right, yes, that. #MommyClone

!Madi serves us each a piece. Amelia and I happily chow down. #Narrator

%This is amazing! #Amelia

%Thanks! The secret ingredient is bananas. #Madi

%So, any ideas? I’m stumped. #Madi

%Well, I think I might only be able to give you Mom Band puns, but I’ll give it a shot. #MommyClone

-> BAN_Choice

== BAN_Choice ==
* [Banana Bread Kennedys]
    ~ Symbol = "%"
    ~ Response = "Ooh... I'll definitely consider that one."
-> CONTINUE2

* [Grateful (Banana) Bread] 
    ~ Symbol = "$"
    ~ Response = "That... actually has a nice ring to it. Strong decisions. That's art, baby!"
-> CONTINUE2

* [Right Said Banana Bread] 
    ~ Symbol = "¥"
    ~ Response = "Hmm... I don't think I get it. "
-> CONTINUE2

== CONTINUE2 ==
{Symbol}{Response} # Madi

$Hey, I was actually wondering if you would want to go to a concert later today. It seems like you also have an interest in bands! #Madi

!Amelia glares at me. #Narrator

%Yeah, that would be awesome! #MommyClone

%Alright, meet up here at eight? #Madi

%Sounds good. #MommyClone

!We finish up our drinks and head out. #Narrator

%Thanks for stopping in! See you later. #Madi

!Madi awkwardly winks at me. I blush in response. #Narrator

%Take care! #MommyClone

-> END