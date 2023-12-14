//This is the file storing dialogues in Scene5: In the Archives
// !Narrator @Player #Amelia/Daughter, %Jade/Mommy 1, ^: Mommy 2, &: NPC/No image

-> Main

=== Main ===
%And this is…the library. #Jade

!Sunlight streams in from floor-to-ceiling arched windows. The walls are lined with packed bookshelves and even more books are scattered across the period-appropriate furniture, Jade is clearly proud of this room. #Narrator
-> ARC_Choice


=== ARC_Choice ===
+ [Look out the window]
    -> Bad

+ [Look at the butterflies]
    -> Good

+ [Pick up a book]
    -> Neutral

=== Bad ===
!I walk to the window and am greeted with a beautiful view of Jade’s backyard. It showcases a beautiful view of the rest of the cul-de-sac. I see a beautiful woman with curly hair, holding a seemingly warm coffee, on a walk. #Narrator
->CHOICEMADE


=== Good ===
$I pinned them all myself. Maybe I could show you some time. #Jade
->CHOICEMADE
-> DONE


=== Neutral ===
%You know, in the Victorian era there was some controversy surrounding reading. Many people thought the more tawdry novels would encourage youths into a life of crime and would cause too much of a distraction from work and school. #Jade
-> DONE
->CHOICEMADE


=== CHOICEMADE ===
%Please, will you join me for tea? #Jade

!I follow Jade to her sitting room, where finger foods have already been set out upon a beautiful, tiered silver tray. I take a seat on one of the high backed chairs as Jade pours and serves me some tea. #Narrator

%I can’t believe we’re having High Tea. #MommyClone

!Jade smiles to herself. #Narrator

%What? #MommyClone

%It is a common misconception that high tea refers to the wealth or class of the people enjoying it, when in fact the “high” refers to both the later time of day that the working class had to enjoy tea and the height of the tables on which they’re served. #Jade

%Oh. #MommyClone

%My dear friend, we’re currently enjoying Afternoon Tea. #Jade

%That’s… informative. #MommyClone

!Jade takes a seat next to me and serves me a tiny sandwich. #Narrator
-> DIA_Choice

=== DIA_Choice ===
+ [Your home is really impressive.] 
    -> Good2

    
+ [Are there a lot of Goths in Maple Bay?]
    -> Neutral2

    
+ [I like your cape.]
    -> Bad2

-> END
=== Good2 ===
&Th…thank you. No one’s ever complimented my home before. #Jade
-> CHOICEMADE2


=== Neutral2 ===
%Plenty, actually. We communicate online on Goth forums. You wouldn’t believe the Victorian-era drama that these people get into. #Jade
-> CHOICEMADE2


=== Bad2 ===
¥It’s a cloak, actually. But thank you. Victorian fashion is very important to me. #Jade
-> CHOICEMADE2


=== CHOICEMADE2 ===
%What got you so interested in Goth stuff? #MommyClone

%Well, when I was a young girl, my father – #Jade

%Did he take you into the city? #MommyClone

¥Sorry? #Jade

%Haha, did you guys see a marching band? #MommyClone

%I’m afraid I don’t understand. #Jade

%..you’re serious? #MommyClone

%Of course. #Jade

%But, it’s… you know. The song. Amelia made me listen to it. #MommyClone

%I’d love to see a marching band. #Jade

¥… #MommyClone

%Nevertheless, I’ve always had a love for art, history, and fashion. What started off as a small hobby of collecting taxidermied animals grew into sort of an obsession. It’s a privilege to be able to appreciate the lies and culture of those who came before us, I think. #Jade

%Why not go all the way? #MommyClone

%I like not dying when I catch a cold. #Jade

!She takes a sip of tea. #Narrator

%I can acknowledge that there are many terrible things about the Victoria era, and to try to live a life that strictly aligns with those ideas would be admittedly horrid. #Jade

%But I think it takes a critical mind to truly appreciate something to the fullest – to be cognizant of its flaws and love it all the same. #Jade

%Tell me, do you have any hobbies? #Jade

!Quick, sound sophisticated! #Narrator

-> HOB_Choice

=== HOB_Choice ===
+ [I like watching soap-making videos on the internet.] 
    -> Choice1
+ [Love me some word jumbles.] 
    -> Choice2
+ [I learned how to juggle once.] 
    -> Choice3

=== Choice1 ===
%Soap is… uh… an important advancement in modern society. Getting rid of germs and stuff. I would say that the people who make soap are… the true heroes here. To watch them work… is an honor. #MommyClone
-> CHOICEMADE3

=== Choice2 ===
%The uh… written word fascinates me. We spend so much time using words, you know? And uh… I think people would appreciate them more if they had to un-jumble them. #MommyClone
-> CHOICEMADE3
-> DONE

=== Choice3 ===
%Gravity is an interesting thing, and um, I believe juggling is the pinnacle of humankind’s interaction with the… gravitational arts. #MommyClone
-> CHOICEMADE3


=== CHOICEMADE3 ===
!Jade looks at me quizzically, but shrugs it off. #Narrator

!We finish our tea and finger sandwiches. #Narrator

!I look at the time, and the grandfather clock is about to strike eleven. #Narrator

%I have to go, but it was really nice talking to you. #MommyClone

%I must agree, it was intriguing hearing you talk about the thing you’re passionate about, and quite honestly, it was rather attractive. #Jade

!My cheeks turn red. #Narrator

%I hope to see you sometime later. #MommyClone

%Perhaps you can visit my place of work next. I have something I would like to show you then. #Jade

%Sounds good! #MommyClone

!I giggle inside as Jade leads me out of her estate. I hope I can see her again. #Narrator

-> END