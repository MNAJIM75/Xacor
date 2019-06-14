﻿namespace Xacor.Graphics.DX11
{
    internal enum DX11CommandType
    {
        Begin,
        End,
        Draw,
        DrawIndexed,
        SetViewport,
        SetScissor,
        SetPrimitiveTopology,
        SetInputLayout,
        SetDepthStencilState,
        SetRasterizerState,
        SetBlendState,
        SetVertexBuffer,
        SetIndexBuffer,
        SetVertexShader,
        SetPixelShader,
        SetComputeShader,
        SetConstantBuffers,
        SetSamplers,
        SetTextures,
        SetRenderTarget,
        SetRenderTargets,
        ClearRenderTarget,
        ClearDepthStencil
    }
}