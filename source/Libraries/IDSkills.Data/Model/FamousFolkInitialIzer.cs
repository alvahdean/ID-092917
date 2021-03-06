﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace IDSkills.Data
{
    public static class FamousFolkSeeder
    {
        public static bool ResetValues { get; set; } = false;
        public static bool Clean { get; set; } = false;
        public static void Initialize(FamousFolksContext context)
        {
            context.Database.Migrate();
            IList<FolkField> fields = new List<FolkField>()
            {
                new FolkField() {Name="Science"},
                new FolkField() {Name="Aviation"},
                new FolkField() {Name="Literature"},
                new FolkField() {Name="Politics"}
            };
            if (Clean)
            {
                context.FolkFields.RemoveRange(context.FolkFields.ToList());
                context.SaveChanges();
            }
            foreach (FolkField f in fields)
            {
                FolkField dbf = context.FolkFields.SingleOrDefault(t => t.Name == f.Name);
                if (dbf == null)
                    context.FolkFields.Add(f);
            }
            context.SaveChanges();
            Dictionary<string, int> fieldMap = new Dictionary<string, int>();
            context.FolkFields.ToList().ForEach(t => fieldMap.Add(t.Name, t.ID));

            IList<Folk> folks = new List<Folk>()
            {
                new Folk()
                {
                    //'Gallileo', 'Galilei', 'Pisa, Italy'
                    FirstName = "Gallileo",
                    LastName = "Galilei",
                    BirthLocation="Pisa, Italy",
                    Bio="<p><b>Galileo Galilei</b> (15 February 1564 – 8 January 1642), commonly known as Galileo, was an Italian physicist, mathematician, astronomer, and philosopher who played a major role in the Scientific Revolution. His achievements include improvements to the telescope and consequent astronomical observations and support for Copernicanism. Galileo has been called the \"father of modern observational astronomy\", the \"father of modern physics\", the \"father of science\", and \"the Father of Modern Science\". According to Stephen Hawking, \"Galileo, perhaps more than any other single person, was responsible for the birth of modern science\".</p>" +
                        "<p> The motion of uniformly accelerated objects, taught in nearly all high school and introductory college physics courses, was studied by Galileo as the subject of kinematics.His contributions to observational astronomy include the telescopic confirmation of the phases of Venus, the discovery of the four largest satellites of Jupiter(named the Galilean moons in his honour), and the observation and analysis of sunspots.Galileo also worked in applied science and technology, inventing an improved military compass and other instruments.</p>" +
                        "<p> Galileo''s championing of heliocentrism was controversial within his lifetime, when most subscribed to either geocentrism or the Tychonic system.He met with opposition from astronomers, who doubted heliocentrism due to the absence of an observed stellar parallax.The matter was investigated by the Roman Inquisition in 1615, and they concluded that it could only be supported as a possibility, not as an established fact.Galileo later defended his views in Dialogue Concerning the Two Chief World Systems, which appeared to attack pope Urban VIII and thus alienated him and the Jesuits, who had both supported Galileo up until this point.He was tried by the Inquisition, found \"vehemently suspect of heresy\", forced to recant, and spent the rest of his life under house arrest.It was while Galileo was under house arrest that he wrote one of his finest works, Two New Sciences. Here he summarized the work he had done some forty years earlier, on the two sciences now called kinematics and strength of materials.</p>",
                    FolkFieldID=fieldMap["Science"]

                },
                new Folk()
                {
                    //'William', 'Shakespeare', 'Stratford, England'
                    FirstName = "William",
                    LastName = "Shakespeare",
                    BirthLocation="Stratford, England",
                    Bio="<p><b>William Shakespeare</b> (baptised 26 April 1564; died 23 April 1616) was an English poet and playwright, widely regarded as the greatest writer in the English language and the world''s pre-eminent dramatist. He is often called England''s national poet and the \"Bard of Avon\". His surviving works, including some collaborations, consist of about 38 plays, 154 sonnets, two long narrative poems, and several other poems. His plays have been translated into every major living language and are performed more often than those of any other playwright."+
                        "<p> Shakespeare was born and raised in Stratford - upon - Avon.At the age of 18, he married Anne Hathaway, with whom he had three children: Susanna, and twins Hamnet and Judith.Between 1585 and 1592, he began a successful career in London as an actor, writer, and part owner of a playing company called the Lord Chamberlain''s Men, later known as the King''s Men.He appears to have retired to Stratford around 1613, where he died three years later.Few records of Shakespeare''s private life survive, and there has been considerable speculation about such matters as his physical appearance, sexuality, religious beliefs, and whether the works attributed to him were written by others.</p>"+
                        "<p>Shakespeare produced most of his known work between 1589 and 1613. His early plays were mainly comedies and histories, genres he raised to the peak of sophistication and artistry by the end of the 16th century. He then wrote mainly tragedies until about 1608, including Hamlet, King Lear, Othello, and Macbeth, considered some of the finest works in the English language.In his last phase, he wrote tragicomedies, also known as romances, and collaborated with other playwrights.</p>"+
                        "<p>Many of his plays were published in editions of varying quality and accuracy during his lifetime.In 1623, two of his former theatrical colleagues published the First Folio, a collected edition of his dramatic works that included all but two of the plays now recognised as Shakespeare''s.</p>"+
                        "<p>Shakespeare was a respected poet and playwright in his own day, but his reputation did not rise to its present heights until the 19th century. The Romantics, in particular, acclaimed Shakespeare''s genius, and the Victorians worshipped Shakespeare with a reverence that George Bernard Shaw called \"bardolatry\". In the 20th century, his work was repeatedly adopted and rediscovered by new movements in scholarship and performance.His plays remain highly popular today and are constantly studied, performed and reinterpreted in diverse cultural and political contexts throughout the world.</p>",
                    FolkFieldID=fieldMap["Literature"]
                },
                new Folk()
                {
                    //'Wilbur', 'Wright', 'Indiana, U.S.'
                    FirstName = "Wilbur",
                    LastName = "Wright",
                    BirthLocation="Indiana, U.S.",
                    Bio="<p><b>The Wright brothers</b>, Orville (August 19, 1871 – January 30, 1948) and Wilbur (April 16, 1867 – May 30, 1912), were two Americans credited with inventing and building the world''s first successful airplane and making the first controlled, powered and sustained heavier-than-air human flight, on December 17, 1903. In the two years afterward, the brothers developed their flying machine into the first practical fixed-wing aircraft. Although not the first to build and fly experimental aircraft, the Wright brothers were the first to invent aircraft controls that made fixed-wing powered flight possible.</p>" +
                        "<p>The brothers'' fundamental breakthrough was their invention of three-axis control, which enabled the pilot to steer the aircraft effectively and to maintain its equilibrium. This method became standard and remains standard on fixed-wing aircraft of all kinds.From the beginning of their aeronautical work, the Wright brothers focused on developing a reliable method of pilot control as the key to solving \"the flying problem\".This approach differed significantly from other experimenters of the time who put more emphasis on developing powerful engines.Using a small homebuilt wind tunnel, the Wrights also collected more accurate data than any before, enabling them to design and build wings and propellers that were more efficient than any before.Their first U.S.patent, 821, 393, did not claim invention of a flying machine, but rather, the invention of a system of aerodynamic control that manipulated a flying machine''s surfaces.</p>" +
                        "<p> They gained the mechanical skills essential for their success by working for years in their shop with printing presses, bicycles, motors, and other machinery.Their work with bicycles in particular influenced their belief that an unstable vehicle like a flying machine could be controlled and balanced with practice.From 1900 until their first powered flights in late 1903, they conducted extensive glider tests that also developed their skills as pilots.Their bicycle shop employee Charlie Taylor became an important part of the team, building their first aircraft engine in close collaboration with the brothers.</p>" +
                        "<p> The Wright brothers'' status as inventors of the airplane has been subject to counter - claims by various parties.Much controversy persists over the many competing claims of early aviators.</p>",
                    FolkFieldID =fieldMap["Aviation"]

                },
                new Folk()
                {
                    //'Orville', 'Wright', 'Indiana, U.S.'
                    FirstName = "Orville",
                    LastName = "Wright",
                    BirthLocation="Indiana, U.S.",
                    Bio="<p><b>The Wright brothers</b>, Orville (August 19, 1871 – January 30, 1948) and Wilbur (April 16, 1867 – May 30, 1912), were two Americans credited with inventing and building the world''s first successful airplane and making the first controlled, powered and sustained heavier-than-air human flight, on December 17, 1903. In the two years afterward, the brothers developed their flying machine into the first practical fixed-wing aircraft. Although not the first to build and fly experimental aircraft, the Wright brothers were the first to invent aircraft controls that made fixed-wing powered flight possible.</p>" +
                        "<p> The brothers'' fundamental breakthrough was their invention of three - axis control, which enabled the pilot to steer the aircraft effectively and to maintain its equilibrium.This method became standard and remains standard on fixed-wing aircraft of all kinds.From the beginning of their aeronautical work, the Wright brothers focused on developing a reliable method of pilot control as the key to solving \"the flying problem\".This approach differed significantly from other experimenters of the time who put more emphasis on developing powerful engines.Using a small homebuilt wind tunnel, the Wrights also collected more accurate data than any before, enabling them to design and build wings and propellers that were more efficient than any before.Their first U.S.patent, 821, 393, did not claim invention of a flying machine, but rather, the invention of a system of aerodynamic control that manipulated a flying machine''s surfaces.</p>" +
                        "<p> They gained the mechanical skills essential for their success by working for years in their shop with printing presses, bicycles, motors, and other machinery.Their work with bicycles in particular influenced their belief that an unstable vehicle like a flying machine could be controlled and balanced with practice.From 1900 until their first powered flights in late 1903, they conducted extensive glider tests that also developed their skills as pilots.Their bicycle shop employee Charlie Taylor became an important part of the team, building their first aircraft engine in close collaboration with the brothers.</p>" +
                        "<p> The Wright brothers'' status as inventors of the airplane has been subject to counter - claims by various parties.Much controversy persists over the many competing claims of early aviators.</p>",
                    FolkFieldID =fieldMap["Aviation"]
                },
                new Folk()
                {
                    //'Abraham', 'Lincoln', 'Kentucky, U.S.'
                    FirstName = "Abraham",
                    LastName = "Lincoln",
                    BirthLocation="Kentucky, U.S.",
                    Bio="<p><b>Abraham Lincoln</b> (February 12, 1809 – April 15, 1865) was the 16th President of the United States, serving from March 1861 until his assassination in 1865. He led the country through a great constitutional, military and moral crisis — the American Civil War — preserving the Union while ending slavery and promoting economic and financial modernization. Reared in a poor family on the western frontier, Lincoln was mostly self-educated. He became a country lawyer, an Illinois state legislator, and a one-term member of the United States House of Representatives, but failed in two attempts at a seat in the United States Senate. He was an affectionate, though often absent, husband and father of four children.</p>" +
                        "<p> After deftly opposing the expansion of slavery in the United States in his campaign debates and speeches, Lincoln secured the Republican nomination and was elected president in 1860.Following declarations of secession by southern slave states, war began in April 1861, and he concentrated on both the military and political dimensions of the war effort, seeking to reunify the nation.He vigorously exercised unprecedented war powers, including the arrest and detention without trial of thousands of suspected secessionists.He prevented British recognition of the Confederacy by skillfully handling the Trent affair late in 1861.He issued his Emancipation Proclamation in 1863 and promoted the passage of the Thirteenth Amendment to the United States Constitution, abolishing slavery.</p>" +
                        "<p> Lincoln closely supervised the war effort, especially the selection of top generals, including the commanding general Ulysses S.Grant.He brought leaders of various factions of his party into his cabinet and pressured them to cooperate.Under his leadership, the Union took control of the border slave states at the start of the war and tried repeatedly to capture the Confederate capital at Richmond.Each time a general failed, Lincoln substituted another until finally Grant succeeded in 1865.An exceptionally astute politician deeply involved with power issues in each state, he reached out to War Democrats and managed his own re - election in the 1864 presidential election.</p>" +
                        "<p> As the leader of the moderate faction of the Republican party, Lincoln came under attack from all sides.Radical Republicans wanted harsher treatment of the South, War Democrats desired more compromise, and Copperheads despised him—not to mention irreconcilable secessionists in reconquered areas.Politically, Lincoln fought back with patronage, by pitting his opponents against each other, and by appealing to the American people with his powers of oratory.His Gettysburg Address of 1863 became the most quoted speech in American history.It was an iconic statement of America''s dedication to the principles of nationalism, equal rights, liberty, and democracy.At the close of the war, Lincoln held a moderate view of Reconstruction, seeking to speedily reunite the nation through a policy of generous reconciliation in the face of lingering and bitter divisiveness.However, just six days after the surrender of Confederate commanding general Robert E.Lee, Lincoln was shot and killed by Confederate sympathizer John Wilkes Booth at Ford''s Theatre in Washington, D.C.His death marked the first assassination of a U.S.president.Lincoln has been consistently ranked by scholars as one of the greatest U.S.presidents.</p>",
                    FolkFieldID =fieldMap["Politics"]
                },
                new Folk()
                {
                    //'George', 'Washington', 'Virginia, U.S.'
                    FirstName = "George",
                    LastName = "Washington",
                    BirthLocation="Virginia, U.S.",
                    Bio="<p><b>George Washington</b> (February 22, 1732 [O.S. February 11, 1731] – December 14, 1799) was the dominant military and political leader of the new United States of America from 1775 to 1799. He led the American victory over Great Britain in the American Revolutionary War as commander-in-chief of the Continental Army in 1775–1783, and presided over the writing of the Constitution in 1787. The unanimous choice to serve as the first President of the United States (1789–1797), Washington presided over the creation of a strong, well-financed national government that stayed neutral in the wars raging in Europe, suppressed rebellion and won acceptance among Americans of all types. His leadership style established many forms and rituals of government that have been used ever since, such as using a cabinet system and delivering an inaugural address. Washington is universally regarded as the \"Father of his Country\".</p>" +
                        "<p> Washington was born into the provincial gentry of a wealthy, well connected Colonial Virginia family who owned tobacco plantations.After his father and older brother both died young, Washington became personally and professionally attached to the powerful Fairfax family, who promoted his career as a surveyor and soldier.Washington quickly became a senior officer of the colonial forces during the first stages of the French and Indian War.Chosen by the Second Continental Congress in 1775 to be commander -in-chief of the Continental Army in the American Revolution, he managed to force the British out of Boston in 1776, but was defeated and nearly captured later that year when he lost New York City.After crossing the Delaware River in the dead of winter, he defeated the enemy in two battles, retook New Jersey, and restored momentum to the Patriot cause.Because of his strategy, Revolutionary forces captured two major British armies at Saratoga in 1777 and Yorktown in 1781.Historians give Washington high marks for his selection and supervision of his generals, his encouragement of morale and ability to hold together the army, his coordination with the state governors and state militia units, his relations with Congress, and his attention to supplies, logistics, and training.In battle, however, Washington was repeatedly outmaneuvered by British generals with larger armies.After victory had been finalized in 1783, Washington resigned rather than seize power, proving his opposition to dictatorship and his commitment to the emerging American political ideology of republicanism.He returned to his home, Mount Vernon, and his domestic life there, continuing to manage a variety of enterprises.Washington''s final 1799 will specified all his slaves be set free.</p>" +
                        "<p> Dissatisfied with the weaknesses of Articles of Confederation, Washington presided over the Constitutional Convention that drafted the United States Constitution in 1787.Elected as the first President of the United States in 1789, he attempted to bring rival factions together to unify the nation.He supported Alexander Hamilton''s programs to pay off all state and national debt, implement an effective tax system, and create a national bank, despite opposition from Thomas Jefferson.Washington proclaimed the U.S.neutral in the wars raging in Europe after 1793.He avoided war with Great Britain and guaranteed a decade of peace and profitable trade by securing the Jay Treaty in 1795, despite intense opposition from the Jeffersonians.Although never officially joining the Federalist Party, he supported its programs.Washington''s \"Farewell Address\" was an influential primer on republican virtue and a stern warning against partisanship, sectionalism, and involvement in foreign wars.</p>" +
                        "<p> Washington had a vision of a great and powerful nation that would be built on republican lines using federal power.He sought to use the national government to preserve liberty, improve infrastructure, open the western lands, promote commerce, found a permanent capital, reduce regional tensions and promote a spirit of American nationalism.At his death, Washington was hailed as \"first in war, first in peace, and first in the hearts of his countrymen\". The Federalists made him the symbol of their party but for many years, the Jeffersonians continued to distrust his influence and delayed building the Washington Monument.As the leader of the first successful revolution against a colonial empire in world history, Washington became an international icon for liberation and nationalism, especially in France and Latin America. He is consistently ranked among the top three presidents of the United States according to polls of both scholars and the general public.</p>",
                    FolkFieldID =fieldMap["Politics"]
                }
            };
            if (Clean)
            {
                context.Folks.RemoveRange(context.Folks.ToList());
                context.SaveChanges();
            }
            foreach (Folk f in folks)
            {
                Folk dbf = context.Folks.SingleOrDefault(t => t.FirstName == f.FirstName && t.LastName == f.LastName);
                if (dbf == null)
                    context.Folks.Add(f);
                else if(ResetValues)
                {
                    dbf.BirthLocation = f.BirthLocation;
                    dbf.Bio = f.Bio;
                    dbf.FolkFieldID = f.FolkFieldID;
                }
            }
            context.SaveChanges();
        }
    }
}
