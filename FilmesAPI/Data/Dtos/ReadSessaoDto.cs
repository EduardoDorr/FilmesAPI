namespace FilmesAPI.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int FilmeId { get; set; }

        public int CinemaId { get; set; }

        public DateTime DataHoraInicio { get; set; }

        //public DateTime DataHoraFinal
        //{
        //    get
        //    {
        //        return DataHoraInicio.AddMinutes(Filme.Duracao + 15);
        //    }
        //}
    }
}
