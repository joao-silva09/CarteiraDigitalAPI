﻿using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Divida
{
    public class GetDividaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NomeDevedor { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public string DataVencimento { get; set; }
        public string DataPagamento { get; set; }
        public TipoDivida TipoDivida { get; set; }
        public SituacaoDivida SituacaoDivida { get; set; }
        public GetContaDto? Conta { get; set; }
    }
}
