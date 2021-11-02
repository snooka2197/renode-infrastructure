﻿//
// Copyright (c) 2010-2021 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using System;
using System.Collections.Generic;

namespace Antmicro.Renode.Peripherals.CPU
{
    public static class VectorInstructionsOpcodes
    {
        public static void EnableVectorOpcodesCounting(this BaseRiscV cpu)
        {
            foreach(var opc in vectorOpcodes)
            {
                cpu.InstallOpcodeCounterPattern(opc.Item1, opc.Item2, opc.Item3);
            }
            cpu.EnableOpcodesCounting = true;
        }
        
        private static List<Tuple<string, uint, uint>> vectorOpcodes = new List<Tuple<string, uint, uint>>
        {
            // name, opcode, mask
            Tuple.Create("vsetivli"         , 0xc0007057u, 0xc000707fu),
            Tuple.Create("vsetvli"          , 0x00007057u, 0x8000707fu),
            Tuple.Create("vsetvl"           , 0x80007057u, 0xfe00707fu),
            Tuple.Create("vlm.v"            , 0x02b00007u, 0xfff0707fu),
            Tuple.Create("vsm.v"            , 0x02b00027u, 0xfff0707fu),
            Tuple.Create("vle8.v"           , 0x00000007u, 0x1df0707fu),
            Tuple.Create("vle16.v"          , 0x00005007u, 0x1df0707fu),
            Tuple.Create("vle32.v"          , 0x00006007u, 0x1df0707fu),
            Tuple.Create("vle64.v"          , 0x00007007u, 0x1df0707fu),
            Tuple.Create("vle128.v"         , 0x10000007u, 0x1df0707fu),
            Tuple.Create("vle256.v"         , 0x10005007u, 0x1df0707fu),
            Tuple.Create("vle512.v"         , 0x10006007u, 0x1df0707fu),
            Tuple.Create("vle1024.v"        , 0x10007007u, 0x1df0707fu),
            Tuple.Create("vse8.v"           , 0x00000027u, 0x1df0707fu),
            Tuple.Create("vse16.v"          , 0x00005027u, 0x1df0707fu),
            Tuple.Create("vse32.v"          , 0x00006027u, 0x1df0707fu),
            Tuple.Create("vse64.v"          , 0x00007027u, 0x1df0707fu),
            Tuple.Create("vse128.v"         , 0x10000027u, 0x1df0707fu),
            Tuple.Create("vse256.v"         , 0x10005027u, 0x1df0707fu),
            Tuple.Create("vse512.v"         , 0x10006027u, 0x1df0707fu),
            Tuple.Create("vse1024.v"        , 0x10007027u, 0x1df0707fu),
            Tuple.Create("vluxei8.v"        , 0x04000007u, 0x1c00707fu),
            Tuple.Create("vluxei16.v"       , 0x04005007u, 0x1c00707fu),
            Tuple.Create("vluxei32.v"       , 0x04006007u, 0x1c00707fu),
            Tuple.Create("vluxei64.v"       , 0x04007007u, 0x1c00707fu),
            Tuple.Create("vluxei128.v"      , 0x14000007u, 0x1c00707fu),
            Tuple.Create("vluxei256.v"      , 0x14005007u, 0x1c00707fu),
            Tuple.Create("vluxei512.v"      , 0x14006007u, 0x1c00707fu),
            Tuple.Create("vluxei1024.v"     , 0x14007007u, 0x1c00707fu),
            Tuple.Create("vsuxei8.v"        , 0x04000027u, 0x1c00707fu),
            Tuple.Create("vsuxei16.v"       , 0x04005027u, 0x1c00707fu),
            Tuple.Create("vsuxei32.v"       , 0x04006027u, 0x1c00707fu),
            Tuple.Create("vsuxei64.v"       , 0x04007027u, 0x1c00707fu),
            Tuple.Create("vsuxei128.v"      , 0x14000027u, 0x1c00707fu),
            Tuple.Create("vsuxei256.v"      , 0x14005027u, 0x1c00707fu),
            Tuple.Create("vsuxei512.v"      , 0x14006027u, 0x1c00707fu),
            Tuple.Create("vsuxei1024.v"     , 0x14007027u, 0x1c00707fu),
            Tuple.Create("vlse8.v"          , 0x08000007u, 0x1c00707fu),
            Tuple.Create("vlse16.v"         , 0x08005007u, 0x1c00707fu),
            Tuple.Create("vlse32.v"         , 0x08006007u, 0x1c00707fu),
            Tuple.Create("vlse64.v"         , 0x08007007u, 0x1c00707fu),
            Tuple.Create("vlse128.v"        , 0x18000007u, 0x1c00707fu),
            Tuple.Create("vlse256.v"        , 0x18005007u, 0x1c00707fu),
            Tuple.Create("vlse512.v"        , 0x18006007u, 0x1c00707fu),
            Tuple.Create("vlse1024.v"       , 0x18007007u, 0x1c00707fu),
            Tuple.Create("vsse8.v"          , 0x08000027u, 0x1c00707fu),
            Tuple.Create("vsse16.v"         , 0x08005027u, 0x1c00707fu),
            Tuple.Create("vsse32.v"         , 0x08006027u, 0x1c00707fu),
            Tuple.Create("vsse64.v"         , 0x08007027u, 0x1c00707fu),
            Tuple.Create("vsse128.v"        , 0x18000027u, 0x1c00707fu),
            Tuple.Create("vsse256.v"        , 0x18005027u, 0x1c00707fu),
            Tuple.Create("vsse512.v"        , 0x18006027u, 0x1c00707fu),
            Tuple.Create("vsse1024.v"       , 0x18007027u, 0x1c00707fu),
            Tuple.Create("vloxei8.v"        , 0x0c000007u, 0x1c00707fu),
            Tuple.Create("vloxei16.v"       , 0x0c005007u, 0x1c00707fu),
            Tuple.Create("vloxei32.v"       , 0x0c006007u, 0x1c00707fu),
            Tuple.Create("vloxei64.v"       , 0x0c007007u, 0x1c00707fu),
            Tuple.Create("vloxei128.v"      , 0x1c000007u, 0x1c00707fu),
            Tuple.Create("vloxei256.v"      , 0x1c005007u, 0x1c00707fu),
            Tuple.Create("vloxei512.v"      , 0x1c006007u, 0x1c00707fu),
            Tuple.Create("vloxei1024.v"     , 0x1c007007u, 0x1c00707fu),
            Tuple.Create("vsoxei8.v"        , 0x0c000027u, 0x1c00707fu),
            Tuple.Create("vsoxei16.v"       , 0x0c005027u, 0x1c00707fu),
            Tuple.Create("vsoxei32.v"       , 0x0c006027u, 0x1c00707fu),
            Tuple.Create("vsoxei64.v"       , 0x0c007027u, 0x1c00707fu),
            Tuple.Create("vsoxei128.v"      , 0x1c000027u, 0x1c00707fu),
            Tuple.Create("vsoxei256.v"      , 0x1c005027u, 0x1c00707fu),
            Tuple.Create("vsoxei512.v"      , 0x1c006027u, 0x1c00707fu),
            Tuple.Create("vsoxei1024.v"     , 0x1c007027u, 0x1c00707fu),
            Tuple.Create("vle8ff.v"         , 0x01000007u, 0x1df0707fu),
            Tuple.Create("vle16ff.v"        , 0x01005007u, 0x1df0707fu),
            Tuple.Create("vle32ff.v"        , 0x01006007u, 0x1df0707fu),
            Tuple.Create("vle64ff.v"        , 0x01007007u, 0x1df0707fu),
            Tuple.Create("vle128ff.v"       , 0x11000007u, 0x1df0707fu),
            Tuple.Create("vle256ff.v"       , 0x11005007u, 0x1df0707fu),
            Tuple.Create("vle512ff.v"       , 0x11006007u, 0x1df0707fu),
            Tuple.Create("vle1024ff.v"      , 0x11007007u, 0x1df0707fu),
            Tuple.Create("vl1re8.v"         , 0x02800007u, 0xfff0707fu),
            Tuple.Create("vl1re16.v"        , 0x02805007u, 0xfff0707fu),
            Tuple.Create("vl1re32.v"        , 0x02806007u, 0xfff0707fu),
            Tuple.Create("vl1re64.v"        , 0x02807007u, 0xfff0707fu),
            Tuple.Create("vl2re8.v"         , 0x22800007u, 0xfff0707fu),
            Tuple.Create("vl2re16.v"        , 0x22805007u, 0xfff0707fu),
            Tuple.Create("vl2re32.v"        , 0x22806007u, 0xfff0707fu),
            Tuple.Create("vl2re64.v"        , 0x22807007u, 0xfff0707fu),
            Tuple.Create("vl4re8.v"         , 0x62800007u, 0xfff0707fu),
            Tuple.Create("vl4re16.v"        , 0x62805007u, 0xfff0707fu),
            Tuple.Create("vl4re32.v"        , 0x62806007u, 0xfff0707fu),
            Tuple.Create("vl4re64.v"        , 0x62807007u, 0xfff0707fu),
            Tuple.Create("vl8re8.v"         , 0xe2800007u, 0xfff0707fu),
            Tuple.Create("vl8re16.v"        , 0xe2805007u, 0xfff0707fu),
            Tuple.Create("vl8re32.v"        , 0xe2806007u, 0xfff0707fu),
            Tuple.Create("vl8re64.v"        , 0xe2807007u, 0xfff0707fu),
            Tuple.Create("vs1r.v"           , 0x02800027u, 0xfff0707fu),
            Tuple.Create("vs2r.v"           , 0x22800027u, 0xfff0707fu),
            Tuple.Create("vs4r.v"           , 0x62800027u, 0xfff0707fu),
            Tuple.Create("vs8r.v"           , 0xe2800027u, 0xfff0707fu),
            Tuple.Create("vfadd.vf"         , 0x00005057u, 0xfc00707fu),
            Tuple.Create("vfsub.vf"         , 0x08005057u, 0xfc00707fu),
            Tuple.Create("vfmin.vf"         , 0x10005057u, 0xfc00707fu),
            Tuple.Create("vfmax.vf"         , 0x18005057u, 0xfc00707fu),
            Tuple.Create("vfsgnj.vf"        , 0x20005057u, 0xfc00707fu),
            Tuple.Create("vfsgnjn.vf"       , 0x24005057u, 0xfc00707fu),
            Tuple.Create("vfsgnjx.vf"       , 0x28005057u, 0xfc00707fu),
            Tuple.Create("vfslide1up.vf"    , 0x38005057u, 0xfc00707fu),
            Tuple.Create("vfslide1down.vf"  , 0x3c005057u, 0xfc00707fu),
            Tuple.Create("vfmv.s.f"         , 0x42005057u, 0xfff0707fu),
            Tuple.Create("vfmerge.vfm"      , 0x5c005057u, 0xfe00707fu),
            Tuple.Create("vfmv.v.f"         , 0x5e005057u, 0xfff0707fu),
            Tuple.Create("vmfeq.vf"         , 0x60005057u, 0xfc00707fu),
            Tuple.Create("vmfle.vf"         , 0x64005057u, 0xfc00707fu),
            Tuple.Create("vmflt.vf"         , 0x6c005057u, 0xfc00707fu),
            Tuple.Create("vmfne.vf"         , 0x70005057u, 0xfc00707fu),
            Tuple.Create("vmfgt.vf"         , 0x74005057u, 0xfc00707fu),
            Tuple.Create("vmfge.vf"         , 0x7c005057u, 0xfc00707fu),
            Tuple.Create("vfdiv.vf"         , 0x80005057u, 0xfc00707fu),
            Tuple.Create("vfrdiv.vf"        , 0x84005057u, 0xfc00707fu),
            Tuple.Create("vfmul.vf"         , 0x90005057u, 0xfc00707fu),
            Tuple.Create("vfrsub.vf"        , 0x9c005057u, 0xfc00707fu),
            Tuple.Create("vfmadd.vf"        , 0xa0005057u, 0xfc00707fu),
            Tuple.Create("vfnmadd.vf"       , 0xa4005057u, 0xfc00707fu),
            Tuple.Create("vfmsub.vf"        , 0xa8005057u, 0xfc00707fu),
            Tuple.Create("vfnmsub.vf"       , 0xac005057u, 0xfc00707fu),
            Tuple.Create("vfmacc.vf"        , 0xb0005057u, 0xfc00707fu),
            Tuple.Create("vfnmacc.vf"       , 0xb4005057u, 0xfc00707fu),
            Tuple.Create("vfmsac.vf"        , 0xb8005057u, 0xfc00707fu),
            Tuple.Create("vfnmsac.vf"       , 0xbc005057u, 0xfc00707fu),
            Tuple.Create("vfwadd.vf"        , 0xc0005057u, 0xfc00707fu),
            Tuple.Create("vfwsub.vf"        , 0xc8005057u, 0xfc00707fu),
            Tuple.Create("vfwadd.wf"        , 0xd0005057u, 0xfc00707fu),
            Tuple.Create("vfwsub.wf"        , 0xd8005057u, 0xfc00707fu),
            Tuple.Create("vfwmul.vf"        , 0xe0005057u, 0xfc00707fu),
            Tuple.Create("vfwmacc.vf"       , 0xf0005057u, 0xfc00707fu),
            Tuple.Create("vfwnmacc.vf"      , 0xf4005057u, 0xfc00707fu),
            Tuple.Create("vfwmsac.vf"       , 0xf8005057u, 0xfc00707fu),
            Tuple.Create("vfwnmsac.vf"      , 0xfc005057u, 0xfc00707fu),
            Tuple.Create("vfadd.vv"         , 0x00001057u, 0xfc00707fu),
            Tuple.Create("vfredusum.vs"     , 0x04001057u, 0xfc00707fu),
            Tuple.Create("vfsub.vv"         , 0x08001057u, 0xfc00707fu),
            Tuple.Create("vfredosum.vs"     , 0x0c001057u, 0xfc00707fu),
            Tuple.Create("vfmin.vv"         , 0x10001057u, 0xfc00707fu),
            Tuple.Create("vfredmin.vs"      , 0x14001057u, 0xfc00707fu),
            Tuple.Create("vfmax.vv"         , 0x18001057u, 0xfc00707fu),
            Tuple.Create("vfredmax.vs"      , 0x1c001057u, 0xfc00707fu),
            Tuple.Create("vfsgnj.vv"        , 0x20001057u, 0xfc00707fu),
            Tuple.Create("vfsgnjn.vv"       , 0x24001057u, 0xfc00707fu),
            Tuple.Create("vfsgnjx.vv"       , 0x28001057u, 0xfc00707fu),
            Tuple.Create("vfmv.f.s"         , 0x42001057u, 0xfe0ff07fu),
            Tuple.Create("vmfeq.vv"         , 0x60001057u, 0xfc00707fu),
            Tuple.Create("vmfle.vv"         , 0x64001057u, 0xfc00707fu),
            Tuple.Create("vmflt.vv"         , 0x6c001057u, 0xfc00707fu),
            Tuple.Create("vmfne.vv"         , 0x70001057u, 0xfc00707fu),
            Tuple.Create("vfdiv.vv"         , 0x80001057u, 0xfc00707fu),
            Tuple.Create("vfmul.vv"         , 0x90001057u, 0xfc00707fu),
            Tuple.Create("vfmadd.vv"        , 0xa0001057u, 0xfc00707fu),
            Tuple.Create("vfnmadd.vv"       , 0xa4001057u, 0xfc00707fu),
            Tuple.Create("vfmsub.vv"        , 0xa8001057u, 0xfc00707fu),
            Tuple.Create("vfnmsub.vv"       , 0xac001057u, 0xfc00707fu),
            Tuple.Create("vfmacc.vv"        , 0xb0001057u, 0xfc00707fu),
            Tuple.Create("vfnmacc.vv"       , 0xb4001057u, 0xfc00707fu),
            Tuple.Create("vfmsac.vv"        , 0xb8001057u, 0xfc00707fu),
            Tuple.Create("vfnmsac.vv"       , 0xbc001057u, 0xfc00707fu),
            Tuple.Create("vfcvt.xu.f.v"     , 0x48001057u, 0xfc0ff07fu),
            Tuple.Create("vfcvt.x.f.v"      , 0x48009057u, 0xfc0ff07fu),
            Tuple.Create("vfcvt.f.xu.v"     , 0x48011057u, 0xfc0ff07fu),
            Tuple.Create("vfcvt.f.x.v"      , 0x48019057u, 0xfc0ff07fu),
            Tuple.Create("vfcvt.rtz.xu.f.v" , 0x48031057u, 0xfc0ff07fu),
            Tuple.Create("vfcvt.rtz.x.f.v"  , 0x48039057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.xu.f.v"    , 0x48041057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.x.f.v"     , 0x48049057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.f.xu.v"    , 0x48051057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.f.x.v"     , 0x48059057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.f.f.v"     , 0x48061057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.rtz.xu.f.v", 0x48071057u, 0xfc0ff07fu),
            Tuple.Create("vfwcvt.rtz.x.f.v" , 0x48079057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.xu.f.w"    , 0x48081057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.x.f.w"     , 0x48089057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.f.xu.w"    , 0x48091057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.f.x.w"     , 0x48099057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.f.f.w"     , 0x480a1057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.rod.f.f.w" , 0x480a9057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.rtz.xu.f.w", 0x480b1057u, 0xfc0ff07fu),
            Tuple.Create("vfncvt.rtz.x.f.w" , 0x480b9057u, 0xfc0ff07fu),
            Tuple.Create("vfsqrt.v"         , 0x4c001057u, 0xfc0ff07fu),
            Tuple.Create("vfrsqrt7.v"       , 0x4c021057u, 0xfc0ff07fu),
            Tuple.Create("vfrec7.v"         , 0x4c029057u, 0xfc0ff07fu),
            Tuple.Create("vfclass.v"        , 0x4c081057u, 0xfc0ff07fu),
            Tuple.Create("vfwadd.vv"        , 0xc0001057u, 0xfc00707fu),
            Tuple.Create("vfwredusum.vs"    , 0xc4001057u, 0xfc00707fu),
            Tuple.Create("vfwsub.vv"        , 0xc8001057u, 0xfc00707fu),
            Tuple.Create("vfwredosum.vs"    , 0xcc001057u, 0xfc00707fu),
            Tuple.Create("vfwadd.wv"        , 0xd0001057u, 0xfc00707fu),
            Tuple.Create("vfwsub.wv"        , 0xd8001057u, 0xfc00707fu),
            Tuple.Create("vfwmul.vv"        , 0xe0001057u, 0xfc00707fu),
            Tuple.Create("vfwmacc.vv"       , 0xf0001057u, 0xfc00707fu),
            Tuple.Create("vfwnmacc.vv"      , 0xf4001057u, 0xfc00707fu),
            Tuple.Create("vfwmsac.vv"       , 0xf8001057u, 0xfc00707fu),
            Tuple.Create("vfwnmsac.vv"      , 0xfc001057u, 0xfc00707fu),
            Tuple.Create("vadd.vx"          , 0x00004057u, 0xfc00707fu),
            Tuple.Create("vsub.vx"          , 0x08004057u, 0xfc00707fu),
            Tuple.Create("vrsub.vx"         , 0x0c004057u, 0xfc00707fu),
            Tuple.Create("vminu.vx"         , 0x10004057u, 0xfc00707fu),
            Tuple.Create("vmin.vx"          , 0x14004057u, 0xfc00707fu),
            Tuple.Create("vmaxu.vx"         , 0x18004057u, 0xfc00707fu),
            Tuple.Create("vmax.vx"          , 0x1c004057u, 0xfc00707fu),
            Tuple.Create("vand.vx"          , 0x24004057u, 0xfc00707fu),
            Tuple.Create("vor.vx"           , 0x28004057u, 0xfc00707fu),
            Tuple.Create("vxor.vx"          , 0x2c004057u, 0xfc00707fu),
            Tuple.Create("vrgather.vx"      , 0x30004057u, 0xfc00707fu),
            Tuple.Create("vslideup.vx"      , 0x38004057u, 0xfc00707fu),
            Tuple.Create("vslidedown.vx"    , 0x3c004057u, 0xfc00707fu),
            Tuple.Create("vadc.vxm"         , 0x40004057u, 0xfe00707fu),
            Tuple.Create("vmadc.vxm"        , 0x44004057u, 0xfe00707fu),
            Tuple.Create("vmadc.vx"         , 0x46004057u, 0xfe00707fu),
            Tuple.Create("vsbc.vxm"         , 0x48004057u, 0xfe00707fu),
            Tuple.Create("vmsbc.vxm"        , 0x4c004057u, 0xfe00707fu),
            Tuple.Create("vmsbc.vx"         , 0x4e004057u, 0xfe00707fu),
            Tuple.Create("vmerge.vxm"       , 0x5c004057u, 0xfe00707fu),
            Tuple.Create("vmv.v.x"          , 0x5e004057u, 0xfff0707fu),
            Tuple.Create("vmseq.vx"         , 0x60004057u, 0xfc00707fu),
            Tuple.Create("vmsne.vx"         , 0x64004057u, 0xfc00707fu),
            Tuple.Create("vmsltu.vx"        , 0x68004057u, 0xfc00707fu),
            Tuple.Create("vmslt.vx"         , 0x6c004057u, 0xfc00707fu),
            Tuple.Create("vmsleu.vx"        , 0x70004057u, 0xfc00707fu),
            Tuple.Create("vmsle.vx"         , 0x74004057u, 0xfc00707fu),
            Tuple.Create("vmsgtu.vx"        , 0x78004057u, 0xfc00707fu),
            Tuple.Create("vmsgt.vx"         , 0x7c004057u, 0xfc00707fu),
            Tuple.Create("vsaddu.vx"        , 0x80004057u, 0xfc00707fu),
            Tuple.Create("vsadd.vx"         , 0x84004057u, 0xfc00707fu),
            Tuple.Create("vssubu.vx"        , 0x88004057u, 0xfc00707fu),
            Tuple.Create("vssub.vx"         , 0x8c004057u, 0xfc00707fu),
            Tuple.Create("vsll.vx"          , 0x94004057u, 0xfc00707fu),
            Tuple.Create("vsmul.vx"         , 0x9c004057u, 0xfc00707fu),
            Tuple.Create("vsrl.vx"          , 0xa0004057u, 0xfc00707fu),
            Tuple.Create("vsra.vx"          , 0xa4004057u, 0xfc00707fu),
            Tuple.Create("vssrl.vx"         , 0xa8004057u, 0xfc00707fu),
            Tuple.Create("vssra.vx"         , 0xac004057u, 0xfc00707fu),
            Tuple.Create("vnsrl.wx"         , 0xb0004057u, 0xfc00707fu),
            Tuple.Create("vnsra.wx"         , 0xb4004057u, 0xfc00707fu),
            Tuple.Create("vnclipu.wx"       , 0xb8004057u, 0xfc00707fu),
            Tuple.Create("vnclip.wx"        , 0xbc004057u, 0xfc00707fu),
            Tuple.Create("vadd.vv"          , 0x00000057u, 0xfc00707fu),
            Tuple.Create("vsub.vv"          , 0x08000057u, 0xfc00707fu),
            Tuple.Create("vminu.vv"         , 0x10000057u, 0xfc00707fu),
            Tuple.Create("vmin.vv"          , 0x14000057u, 0xfc00707fu),
            Tuple.Create("vmaxu.vv"         , 0x18000057u, 0xfc00707fu),
            Tuple.Create("vmax.vv"          , 0x1c000057u, 0xfc00707fu),
            Tuple.Create("vand.vv"          , 0x24000057u, 0xfc00707fu),
            Tuple.Create("vor.vv"           , 0x28000057u, 0xfc00707fu),
            Tuple.Create("vxor.vv"          , 0x2c000057u, 0xfc00707fu),
            Tuple.Create("vrgather.vv"      , 0x30000057u, 0xfc00707fu),
            Tuple.Create("vrgatherei16.vv"  , 0x38000057u, 0xfc00707fu),
            Tuple.Create("vadc.vvm"         , 0x40000057u, 0xfe00707fu),
            Tuple.Create("vmadc.vvm"        , 0x44000057u, 0xfe00707fu),
            Tuple.Create("vmadc.vv"         , 0x46000057u, 0xfe00707fu),
            Tuple.Create("vsbc.vvm"         , 0x48000057u, 0xfe00707fu),
            Tuple.Create("vmsbc.vvm"        , 0x4c000057u, 0xfe00707fu),
            Tuple.Create("vmsbc.vv"         , 0x4e000057u, 0xfe00707fu),
            Tuple.Create("vmerge.vvm"       , 0x5c000057u, 0xfe00707fu),
            Tuple.Create("vmv.v.v"          , 0x5e000057u, 0xfff0707fu),
            Tuple.Create("vmseq.vv"         , 0x60000057u, 0xfc00707fu),
            Tuple.Create("vmsne.vv"         , 0x64000057u, 0xfc00707fu),
            Tuple.Create("vmsltu.vv"        , 0x68000057u, 0xfc00707fu),
            Tuple.Create("vmslt.vv"         , 0x6c000057u, 0xfc00707fu),
            Tuple.Create("vmsleu.vv"        , 0x70000057u, 0xfc00707fu),
            Tuple.Create("vmsle.vv"         , 0x74000057u, 0xfc00707fu),
            Tuple.Create("vsaddu.vv"        , 0x80000057u, 0xfc00707fu),
            Tuple.Create("vsadd.vv"         , 0x84000057u, 0xfc00707fu),
            Tuple.Create("vssubu.vv"        , 0x88000057u, 0xfc00707fu),
            Tuple.Create("vssub.vv"         , 0x8c000057u, 0xfc00707fu),
            Tuple.Create("vsll.vv"          , 0x94000057u, 0xfc00707fu),
            Tuple.Create("vsmul.vv"         , 0x9c000057u, 0xfc00707fu),
            Tuple.Create("vsrl.vv"          , 0xa0000057u, 0xfc00707fu),
            Tuple.Create("vsra.vv"          , 0xa4000057u, 0xfc00707fu),
            Tuple.Create("vssrl.vv"         , 0xa8000057u, 0xfc00707fu),
            Tuple.Create("vssra.vv"         , 0xac000057u, 0xfc00707fu),
            Tuple.Create("vnsrl.wv"         , 0xb0000057u, 0xfc00707fu),
            Tuple.Create("vnsra.wv"         , 0xb4000057u, 0xfc00707fu),
            Tuple.Create("vnclipu.wv"       , 0xb8000057u, 0xfc00707fu),
            Tuple.Create("vnclip.wv"        , 0xbc000057u, 0xfc00707fu),
            Tuple.Create("vwredsumu.vs"     , 0xc0000057u, 0xfc00707fu),
            Tuple.Create("vwredsum.vs"      , 0xc4000057u, 0xfc00707fu),
            Tuple.Create("vadd.vi"          , 0x00003057u, 0xfc00707fu),
            Tuple.Create("vrsub.vi"         , 0x0c003057u, 0xfc00707fu),
            Tuple.Create("vand.vi"          , 0x24003057u, 0xfc00707fu),
            Tuple.Create("vor.vi"           , 0x28003057u, 0xfc00707fu),
            Tuple.Create("vxor.vi"          , 0x2c003057u, 0xfc00707fu),
            Tuple.Create("vrgather.vi"      , 0x30003057u, 0xfc00707fu),
            Tuple.Create("vslideup.vi"      , 0x38003057u, 0xfc00707fu),
            Tuple.Create("vslidedown.vi"    , 0x3c003057u, 0xfc00707fu),
            Tuple.Create("vadc.vim"         , 0x40003057u, 0xfe00707fu),
            Tuple.Create("vmadc.vim"        , 0x44003057u, 0xfe00707fu),
            Tuple.Create("vmadc.vi"         , 0x46003057u, 0xfe00707fu),
            Tuple.Create("vmerge.vim"       , 0x5c003057u, 0xfe00707fu),
            Tuple.Create("vmv.v.i"          , 0x5e003057u, 0xfff0707fu),
            Tuple.Create("vmseq.vi"         , 0x60003057u, 0xfc00707fu),
            Tuple.Create("vmsne.vi"         , 0x64003057u, 0xfc00707fu),
            Tuple.Create("vmsleu.vi"        , 0x70003057u, 0xfc00707fu),
            Tuple.Create("vmsle.vi"         , 0x74003057u, 0xfc00707fu),
            Tuple.Create("vmsgtu.vi"        , 0x78003057u, 0xfc00707fu),
            Tuple.Create("vmsgt.vi"         , 0x7c003057u, 0xfc00707fu),
            Tuple.Create("vsaddu.vi"        , 0x80003057u, 0xfc00707fu),
            Tuple.Create("vsadd.vi"         , 0x84003057u, 0xfc00707fu),
            Tuple.Create("vsll.vi"          , 0x94003057u, 0xfc00707fu),
            Tuple.Create("vmv1r.v"          , 0x9e003057u, 0xfe0ff07fu),
            Tuple.Create("vmv2r.v"          , 0x9e00b057u, 0xfe0ff07fu),
            Tuple.Create("vmv4r.v"          , 0x9e01b057u, 0xfe0ff07fu),
            Tuple.Create("vmv8r.v"          , 0x9e03b057u, 0xfe0ff07fu),
            Tuple.Create("vsrl.vi"          , 0xa0003057u, 0xfc00707fu),
            Tuple.Create("vsra.vi"          , 0xa4003057u, 0xfc00707fu),
            Tuple.Create("vssrl.vi"         , 0xa8003057u, 0xfc00707fu),
            Tuple.Create("vssra.vi"         , 0xac003057u, 0xfc00707fu),
            Tuple.Create("vnsrl.wi"         , 0xb0003057u, 0xfc00707fu),
            Tuple.Create("vnsra.wi"         , 0xb4003057u, 0xfc00707fu),
            Tuple.Create("vnclipu.wi"       , 0xb8003057u, 0xfc00707fu),
            Tuple.Create("vnclip.wi"        , 0xbc003057u, 0xfc00707fu),
            Tuple.Create("vredsum.vs"       , 0x00002057u, 0xfc00707fu),
            Tuple.Create("vredand.vs"       , 0x04002057u, 0xfc00707fu),
            Tuple.Create("vredor.vs"        , 0x08002057u, 0xfc00707fu),
            Tuple.Create("vredxor.vs"       , 0x0c002057u, 0xfc00707fu),
            Tuple.Create("vredminu.vs"      , 0x10002057u, 0xfc00707fu),
            Tuple.Create("vredmin.vs"       , 0x14002057u, 0xfc00707fu),
            Tuple.Create("vredmaxu.vs"      , 0x18002057u, 0xfc00707fu),
            Tuple.Create("vredmax.vs"       , 0x1c002057u, 0xfc00707fu),
            Tuple.Create("vaaddu.vv"        , 0x20002057u, 0xfc00707fu),
            Tuple.Create("vaadd.vv"         , 0x24002057u, 0xfc00707fu),
            Tuple.Create("vasubu.vv"        , 0x28002057u, 0xfc00707fu),
            Tuple.Create("vasub.vv"         , 0x2c002057u, 0xfc00707fu),
            Tuple.Create("vmv.x.s"          , 0x42002057u, 0xfe0ff07fu),
            Tuple.Create("vzext.vf8"        , 0x48012057u, 0xfc0ff07fu),
            Tuple.Create("vsext.vf8"        , 0x4801a057u, 0xfc0ff07fu),
            Tuple.Create("vzext.vf4"        , 0x48022057u, 0xfc0ff07fu),
            Tuple.Create("vsext.vf4"        , 0x4802a057u, 0xfc0ff07fu),
            Tuple.Create("vzext.vf2"        , 0x48032057u, 0xfc0ff07fu),
            Tuple.Create("vsext.vf2"        , 0x4803a057u, 0xfc0ff07fu),
            Tuple.Create("vcompress.vm"     , 0x5e002057u, 0xfe00707fu),
            Tuple.Create("vmandnot.mm"      , 0x60002057u, 0xfc00707fu),
            Tuple.Create("vmand.mm"         , 0x64002057u, 0xfc00707fu),
            Tuple.Create("vmor.mm"          , 0x68002057u, 0xfc00707fu),
            Tuple.Create("vmxor.mm"         , 0x6c002057u, 0xfc00707fu),
            Tuple.Create("vmornot.mm"       , 0x70002057u, 0xfc00707fu),
            Tuple.Create("vmnand.mm"        , 0x74002057u, 0xfc00707fu),
            Tuple.Create("vmnor.mm"         , 0x78002057u, 0xfc00707fu),
            Tuple.Create("vmxnor.mm"        , 0x7c002057u, 0xfc00707fu),
            Tuple.Create("vmsbf.m"          , 0x5000a057u, 0xfc0ff07fu),
            Tuple.Create("vmsof.m"          , 0x50012057u, 0xfc0ff07fu),
            Tuple.Create("vmsif.m"          , 0x5001a057u, 0xfc0ff07fu),
            Tuple.Create("viota.m"          , 0x50082057u, 0xfc0ff07fu),
            Tuple.Create("vid.v"            , 0x5008a057u, 0xfdfff07fu),
            Tuple.Create("vcpop.m"          , 0x40082057u, 0xfc0ff07fu),
            Tuple.Create("vfirst.m"         , 0x4008a057u, 0xfc0ff07fu),
            Tuple.Create("vdivu.vv"         , 0x80002057u, 0xfc00707fu),
            Tuple.Create("vdiv.vv"          , 0x84002057u, 0xfc00707fu),
            Tuple.Create("vremu.vv"         , 0x88002057u, 0xfc00707fu),
            Tuple.Create("vrem.vv"          , 0x8c002057u, 0xfc00707fu),
            Tuple.Create("vmulhu.vv"        , 0x90002057u, 0xfc00707fu),
            Tuple.Create("vmul.vv"          , 0x94002057u, 0xfc00707fu),
            Tuple.Create("vmulhsu.vv"       , 0x98002057u, 0xfc00707fu),
            Tuple.Create("vmulh.vv"         , 0x9c002057u, 0xfc00707fu),
            Tuple.Create("vmadd.vv"         , 0xa4002057u, 0xfc00707fu),
            Tuple.Create("vnmsub.vv"        , 0xac002057u, 0xfc00707fu),
            Tuple.Create("vmacc.vv"         , 0xb4002057u, 0xfc00707fu),
            Tuple.Create("vnmsac.vv"        , 0xbc002057u, 0xfc00707fu),
            Tuple.Create("vwaddu.vv"        , 0xc0002057u, 0xfc00707fu),
            Tuple.Create("vwadd.vv"         , 0xc4002057u, 0xfc00707fu),
            Tuple.Create("vwsubu.vv"        , 0xc8002057u, 0xfc00707fu),
            Tuple.Create("vwsub.vv"         , 0xcc002057u, 0xfc00707fu),
            Tuple.Create("vwaddu.wv"        , 0xd0002057u, 0xfc00707fu),
            Tuple.Create("vwadd.wv"         , 0xd4002057u, 0xfc00707fu),
            Tuple.Create("vwsubu.wv"        , 0xd8002057u, 0xfc00707fu),
            Tuple.Create("vwsub.wv"         , 0xdc002057u, 0xfc00707fu),
            Tuple.Create("vwmulu.vv"        , 0xe0002057u, 0xfc00707fu),
            Tuple.Create("vwmulsu.vv"       , 0xe8002057u, 0xfc00707fu),
            Tuple.Create("vwmul.vv"         , 0xec002057u, 0xfc00707fu),
            Tuple.Create("vwmaccu.vv"       , 0xf0002057u, 0xfc00707fu),
            Tuple.Create("vwmacc.vv"        , 0xf4002057u, 0xfc00707fu),
            Tuple.Create("vwmaccsu.vv"      , 0xfc002057u, 0xfc00707fu),
            Tuple.Create("vaaddu.vx"        , 0x20006057u, 0xfc00707fu),
            Tuple.Create("vaadd.vx"         , 0x24006057u, 0xfc00707fu),
            Tuple.Create("vasubu.vx"        , 0x28006057u, 0xfc00707fu),
            Tuple.Create("vasub.vx"         , 0x2c006057u, 0xfc00707fu),
            Tuple.Create("vmv.s.x"          , 0x42006057u, 0xfff0707fu),
            Tuple.Create("vslide1up.vx"     , 0x38006057u, 0xfc00707fu),
            Tuple.Create("vslide1down.vx"   , 0x3c006057u, 0xfc00707fu),
            Tuple.Create("vdivu.vx"         , 0x80006057u, 0xfc00707fu),
            Tuple.Create("vdiv.vx"          , 0x84006057u, 0xfc00707fu),
            Tuple.Create("vremu.vx"         , 0x88006057u, 0xfc00707fu),
            Tuple.Create("vrem.vx"          , 0x8c006057u, 0xfc00707fu),
            Tuple.Create("vmulhu.vx"        , 0x90006057u, 0xfc00707fu),
            Tuple.Create("vmul.vx"          , 0x94006057u, 0xfc00707fu),
            Tuple.Create("vmulhsu.vx"       , 0x98006057u, 0xfc00707fu),
            Tuple.Create("vmulh.vx"         , 0x9c006057u, 0xfc00707fu),
            Tuple.Create("vmadd.vx"         , 0xa4006057u, 0xfc00707fu),
            Tuple.Create("vnmsub.vx"        , 0xac006057u, 0xfc00707fu),
            Tuple.Create("vmacc.vx"         , 0xb4006057u, 0xfc00707fu),
            Tuple.Create("vnmsac.vx"        , 0xbc006057u, 0xfc00707fu),
            Tuple.Create("vwaddu.vx"        , 0xc0006057u, 0xfc00707fu),
            Tuple.Create("vwadd.vx"         , 0xc4006057u, 0xfc00707fu),
            Tuple.Create("vwsubu.vx"        , 0xc8006057u, 0xfc00707fu),
            Tuple.Create("vwsub.vx"         , 0xcc006057u, 0xfc00707fu),
            Tuple.Create("vwaddu.wx"        , 0xd0006057u, 0xfc00707fu),
            Tuple.Create("vwadd.wx"         , 0xd4006057u, 0xfc00707fu),
            Tuple.Create("vwsubu.wx"        , 0xd8006057u, 0xfc00707fu),
            Tuple.Create("vwsub.wx"         , 0xdc006057u, 0xfc00707fu),
            Tuple.Create("vwmulu.vx"        , 0xe0006057u, 0xfc00707fu),
            Tuple.Create("vwmulsu.vx"       , 0xe8006057u, 0xfc00707fu),
            Tuple.Create("vwmul.vx"         , 0xec006057u, 0xfc00707fu),
            Tuple.Create("vwmaccu.vx"       , 0xf0006057u, 0xfc00707fu),
            Tuple.Create("vwmacc.vx"        , 0xf4006057u, 0xfc00707fu),
            Tuple.Create("vwmaccus.vx"      , 0xf8006057u, 0xfc00707fu),
            Tuple.Create("vwmaccsu.vx"      , 0xfc006057u, 0xfc00707fu),
            Tuple.Create("vamoswapei8.v"    , 0x0800002fu, 0xf800707fu),
            Tuple.Create("vamoaddei8.v"     , 0x0000002fu, 0xf800707fu),
            Tuple.Create("vamoxorei8.v"     , 0x2000002fu, 0xf800707fu),
            Tuple.Create("vamoandei8.v"     , 0x6000002fu, 0xf800707fu),
            Tuple.Create("vamoorei8.v"      , 0x4000002fu, 0xf800707fu),
            Tuple.Create("vamominei8.v"     , 0x8000002fu, 0xf800707fu),
            Tuple.Create("vamomaxei8.v"     , 0xa000002fu, 0xf800707fu),
            Tuple.Create("vamominuei8.v"    , 0xc000002fu, 0xf800707fu),
            Tuple.Create("vamomaxuei8.v"    , 0xe000002fu, 0xf800707fu),
            Tuple.Create("vamoswapei16.v"   , 0x0800502fu, 0xf800707fu),
            Tuple.Create("vamoaddei16.v"    , 0x0000502fu, 0xf800707fu),
            Tuple.Create("vamoxorei16.v"    , 0x2000502fu, 0xf800707fu),
            Tuple.Create("vamoandei16.v"    , 0x6000502fu, 0xf800707fu),
            Tuple.Create("vamoorei16.v"     , 0x4000502fu, 0xf800707fu),
            Tuple.Create("vamominei16.v"    , 0x8000502fu, 0xf800707fu),
            Tuple.Create("vamomaxei16.v"    , 0xa000502fu, 0xf800707fu),
            Tuple.Create("vamominuei16.v"   , 0xc000502fu, 0xf800707fu),
            Tuple.Create("vamomaxuei16.v"   , 0xe000502fu, 0xf800707fu),
            Tuple.Create("vamoswapei32.v"   , 0x0800602fu, 0xf800707fu),
            Tuple.Create("vamoaddei32.v"    , 0x0000602fu, 0xf800707fu),
            Tuple.Create("vamoxorei32.v"    , 0x2000602fu, 0xf800707fu),
            Tuple.Create("vamoandei32.v"    , 0x6000602fu, 0xf800707fu),
            Tuple.Create("vamoorei32.v"     , 0x4000602fu, 0xf800707fu),
            Tuple.Create("vamominei32.v"    , 0x8000602fu, 0xf800707fu),
            Tuple.Create("vamomaxei32.v"    , 0xa000602fu, 0xf800707fu),
            Tuple.Create("vamominuei32.v"   , 0xc000602fu, 0xf800707fu),
            Tuple.Create("vamomaxuei32.v"   , 0xe000602fu, 0xf800707fu),
            Tuple.Create("vamoswapei64.v"   , 0x0800702fu, 0xf800707fu),
            Tuple.Create("vamoaddei64.v"    , 0x0000702fu, 0xf800707fu),
            Tuple.Create("vamoxorei64.v"    , 0x2000702fu, 0xf800707fu),
            Tuple.Create("vamoandei64.v"    , 0x6000702fu, 0xf800707fu),
            Tuple.Create("vamoorei64.v"     , 0x4000702fu, 0xf800707fu),
            Tuple.Create("vamominei64.v"    , 0x8000702fu, 0xf800707fu),
            Tuple.Create("vamomaxei64.v"    , 0xa000702fu, 0xf800707fu),
            Tuple.Create("vamominuei64.v"   , 0xc000702fu, 0xf800707fu),
            Tuple.Create("vamomaxuei64.v"   , 0xe000702fu, 0xf800707fu)
        };
    }
}