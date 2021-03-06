﻿using System;
using Memory;
using TestMemory.Helper;

namespace Memory.DataStructure
{
    public static class PlayerInfo
    {
        public static PlaterInfoStructure d;

        public static void ResolvePlayerFromBytes(byte[] source)
        {
            var entry = new PlaterInfoStructure();
            try
            {
                entry.Name = MemoryLib.GetStringFromBytes(source, 1);


                entry.JobID = source[0x66];
                //entry.Job = (Actor.Job)entry.JobID;

                #region Job Levels

                var step = 2;
                var i = 0x68 - step;

                var nowLv = source[i += step];

                entry.PGL = source[i += step];//格闘士■
                entry.GLD = source[i += step];//剣術士■
                entry.MRD = source[i += step];//斧術士●■
                entry.ARC = source[i += step];//弓術士
                entry.LNC = source[i += step];//槍術士■  
                entry.THM = source[i += step];//呪術士
            
                entry.CNJ = source[i += step];//幻術士■

                entry.CPT = source[i += step];//木工士
                entry.BSM = source[i += step];//黒
                entry.ARM = source[i += step];
                entry.GSM = source[i += step];
                entry.LTW = source[i += step];
                entry.WVR = source[i += step];
 
                entry.CUL = source[i += step];

                entry.MIN = source[i += step];//採掘

                entry.BTN = source[i += step];//園芸士
                entry.ACN = source[i += step];
                entry.FSH = source[i += step];//漁師●
                entry.ALC = source[i += step];//巴術●
                entry.ROG = source[i += step];//双剣士●

                entry.MCH = source[i += step];//機工■
                entry.DRK = source[i += step];//暗黒■
                entry.AST = source[i += step];//占■


                #endregion

                #region Current Experience

                step = 4;
                i = 0x98 - step;

                entry.PGL_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.GLD_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.MRD_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.ARC_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.LNC_CurrentEXP = BitConverter.ToInt32(source, i += step);//■
                entry.THM_CurrentEXP = BitConverter.ToInt32(source, i += step);


                entry.CNJ_CurrentEXP = BitConverter.ToInt32(source, i += step);//■

                entry.CPT_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.BSM_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.ARM_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.GSM_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.LTW_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.WVR_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.ALC_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.CUL_CurrentEXP = BitConverter.ToInt32(source, i += step);

                entry.MIN_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.BTN_CurrentEXP = BitConverter.ToInt32(source, i += step);//■
                entry.ACN_CurrentEXP = BitConverter.ToInt32(source, i += step);



                entry.FSH_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.ROG_CurrentEXP = BitConverter.ToInt32(source, i += step);

                entry.MCH_CurrentEXP = BitConverter.ToInt32(source, i += step);
                entry.DRK_CurrentEXP = BitConverter.ToInt32(source, i += step);

                entry.AST_CurrentEXP = BitConverter.ToInt32(source, i += step);
 

                #endregion

                #region Base Stats

                step = 4;
                i = 0x100;

                entry.BaseStrength = BitConverter.ToInt16(source, i += step);
                entry.BaseDexterity = BitConverter.ToInt16(source, i += step);
                entry.BaseVitality = BitConverter.ToInt16(source, i += step);
                entry.BaseIntelligence = BitConverter.ToInt16(source, i += step);
                entry.BaseMind = BitConverter.ToInt16(source, i += step);
                entry.BasePiety = BitConverter.ToInt16(source, i += step);

                #endregion

                #region Base Stats (base+gear+bonus)

                step = 4;
                i = 0x11C;

                entry.Strength = BitConverter.ToInt16(source, i += step);
                entry.Dexterity = BitConverter.ToInt16(source, i += step);
                entry.Vitality = BitConverter.ToInt16(source, i += step);
                entry.Intelligence = BitConverter.ToInt16(source, i += step);
                entry.Mind = BitConverter.ToInt16(source, i += step);
                entry.Piety = BitConverter.ToInt16(source, i += step);

                #endregion

                #region Basic Info

                step = 4;
                i = 0x134;

                entry.HPMax = BitConverter.ToInt16(source, i += step);
                entry.MPMax = BitConverter.ToInt16(source, i += step);
                entry.TPMax = BitConverter.ToInt16(source, i += step);
                entry.GPMax = BitConverter.ToInt16(source, i += step);
                entry.CPMax = BitConverter.ToInt16(source, i += step);

                #endregion

                #region Offensive Properties

                entry.Accuracy = BitConverter.ToInt16(source, 0x174);//
                entry.CriticalHitRate = BitConverter.ToInt16(source, 0x188);//
                entry.Determination = BitConverter.ToInt16(source, 0x1CC);//

                #endregion

                #region Defensive Properties

                entry.Parry = BitConverter.ToInt16(source, 0x178);//
                entry.Defense = BitConverter.ToInt16(source, 0x170);//
                entry.MagicDefense = BitConverter.ToInt16(source, 0x17C);//

                #endregion

                #region Phyiscal Properties

                entry.AttackPower = BitConverter.ToInt16(source, 0x16C);//
                entry.SkillSpeed = BitConverter.ToInt16(source, 0x1d0);//

                #endregion

                #region Mental Properties

                entry.SpellSpeed = BitConverter.ToInt16(source, 0x1D4);//
                entry.AttackMagicPotency = BitConverter.ToInt16(source, 0x1A0);//
                entry.HealingMagicPotency = BitConverter.ToInt16(source, 0x1A4);//

                #endregion

                #region Status Resistances

                //entry.SlowResistance = BitConverter.ToInt16(source, 0x1C8);
                //entry.SilenceResistance = BitConverter.ToInt16(source, 0x1CC);
                //entry.BindResistance = BitConverter.ToInt16(source, 0x1D0);
                //entry.PoisionResistance = BitConverter.ToInt16(source, 0x1D4);
                //entry.StunResistance = BitConverter.ToInt16(source, 0x1D8);
                //entry.SleepResistance = BitConverter.ToInt16(source, 0x1DC);
                //entry.BindResistance = BitConverter.ToInt16(source, 0x1E0);
                //entry.HeavyResistance = BitConverter.ToInt16(source, 0x1E4);

                #endregion

                #region Elemental Resistances

                //step = 4;
                //i = 0x1B0;

                //entry.FireResistance = BitConverter.ToInt16(source, i += step);//
                //entry.IceResistance = BitConverter.ToInt16(source, i += step);//
                //entry.WindResistance = BitConverter.ToInt16(source, i += step);//
                //entry.EarthResistance = BitConverter.ToInt16(source, i += step);//
                //entry.LightningResistance = BitConverter.ToInt16(source, i += step);//
                //entry.WaterResistance = BitConverter.ToInt16(source, i += step);//

                #endregion

                #region Physical Resistances

                step = 4;
                i = 0x190;

                entry.SlashingResistance = BitConverter.ToInt16(source, i += step);//
                entry.PiercingResistance = BitConverter.ToInt16(source, i += step);//
                entry.BluntResistance = BitConverter.ToInt16(source, i += step);//

                #endregion

                #region Crafting

                //entry.Craftmanship = BitConverter.ToInt16(source, 0x230);
                //entry.Control = BitConverter.ToInt16(source, 0x234);

                #endregion

                #region Gathering

                //entry.Gathering = BitConverter.ToInt16(source, 0x238);
                //entry.Perception = BitConverter.ToInt16(source, 0x23C);

                #endregion


            }
            catch (Exception ex)
            {
            }
            d = entry;

        }
    }
}
