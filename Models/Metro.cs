namespace MAI.Models
{
    /// <summary>
    /// Represents a single metro station with its name and geographical coordinates.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Gets or sets the name of the metro station.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the latitude coordinate of the metro station.
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude coordinate of the metro station.
        /// </summary>
        public double Longitude { get; set; }
    }

    /// <summary>
    /// Represents a metro line with its name and a list of stations it serves.
    /// </summary>
    public class MetroLine
    {
        /// <summary>
        /// Gets or sets the name of the metro line.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the list of station names belonging to this metro line.
        /// </summary>
        public List<string> Stations { get; set; } = new List<string>();
    }

    /// <summary>
    /// Provides static data for metro stations and lines, specifically for the Mexico City Metro system.
    /// This includes a dictionary of all stations with their geographical data and a list of metro lines
    /// with their respective stations.
    /// </summary>
    public static class MetroData
    {
        /// <summary>
        /// A dictionary containing all known metro stations, mapped by their name.
        /// Each key is a station name string, and its value is a <see cref="Station"/> object.
        /// </summary>
        public static Dictionary<string, Station> Stations = new Dictionary<string, Station>
        {
            { "Observatorio", new Station { Name = "Observatorio", Latitude = 19.3982, Longitude = -99.2004 } },
            { "Tacubaya", new Station { Name = "Tacubaya", Latitude = 19.4032, Longitude = -99.1871 } },
            { "Juanacatlán", new Station { Name = "Juanacatlán", Latitude = 19.4129, Longitude = -99.1821 } },
            { "Chapultepec", new Station { Name = "Chapultepec", Latitude = 19.4206, Longitude = -99.1762 } },
            { "Sevilla", new Station { Name = "Sevilla", Latitude = 19.4219, Longitude = -99.1706 } },
            { "Insurgentes", new Station { Name = "Insurgentes", Latitude = 19.4233, Longitude = -99.1631 } },
            { "Cuauhtémoc", new Station { Name = "Cuauhtémoc", Latitude = 19.4258, Longitude = -99.1546 } },
            { "Balderas", new Station { Name = "Balderas", Latitude = 19.4274, Longitude = -99.1491 } },
            { "Salto del Agua", new Station { Name = "Salto del Agua", Latitude = 19.4266, Longitude = -99.1423 } },
            { "Isabel la Católica", new Station { Name = "Isabel la Católica", Latitude = 19.4265, Longitude = -99.1376 } },
            { "Pino Suárez", new Station { Name = "Pino Suárez", Latitude = 19.4259, Longitude = -99.1330 } },
            { "Merced", new Station { Name = "Merced", Latitude = 19.4256, Longitude = -99.1245 } },
            { "Candelaria", new Station { Name = "Candelaria", Latitude = 19.4290, Longitude = -99.1196 } },
            { "San Lázaro", new Station { Name = "San Lázaro", Latitude = 19.4303, Longitude = -99.1148 } },
            { "Moctezuma", new Station { Name = "Moctezuma", Latitude = 19.4276, Longitude = -99.1097 } },
            { "Balbuena", new Station { Name = "Balbuena", Latitude = 19.4237, Longitude = -99.1027 } },
            { "Blvd. Puerto Aéreo", new Station { Name = "Blvd. Puerto Aéreo", Latitude = 19.4197, Longitude = -99.0960 } },
            { "Gómez Farías", new Station { Name = "Gómez Farías", Latitude = 19.4165, Longitude = -99.0904 } },
            { "Zaragoza", new Station { Name = "Zaragoza", Latitude = 19.4122, Longitude = -99.0824 } },
            { "Pantitlán", new Station { Name = "Pantitlán", Latitude = 19.4153, Longitude = -99.0723 } },
            { "Cuatro Caminos", new Station { Name = "Cuatro Caminos", Latitude = 19.4594, Longitude = -99.2158 } },
            { "Panteones", new Station { Name = "Panteones", Latitude = 19.4586, Longitude = -99.2031 } },
            { "Tacuba", new Station { Name = "Tacuba", Latitude = 19.4586, Longitude = -99.1884 } },
            { "Cuitláhuac", new Station { Name = "Cuitláhuac", Latitude = 19.4574, Longitude = -99.1750 } },
            { "Popotla", new Station { Name = "Popotla", Latitude = 19.4520, Longitude = -99.1692 } },
            { "Colegio Militar", new Station { Name = "Colegio Militar", Latitude = 19.4484, Longitude = -99.1720 } },
            { "Normal", new Station { Name = "Normal", Latitude = 19.4443, Longitude = -99.1673 } },
            { "San Cosme", new Station { Name = "San Cosme", Latitude = 19.4413, Longitude = -99.1611 } },
            { "Revolución", new Station { Name = "Revolución", Latitude = 19.4396, Longitude = -99.1546 } },
            { "Hidalgo", new Station { Name = "Hidalgo", Latitude = 19.4374, Longitude = -99.1473 } },
            { "Bellas Artes", new Station { Name = "Bellas Artes", Latitude = 19.4362, Longitude = -99.1418 } },
            { "Allende", new Station { Name = "Allende", Latitude = 19.4353, Longitude = -99.1373 } },
            { "Zócalo", new Station { Name = "Zócalo", Latitude = 19.4330, Longitude = -99.1326 } },
            { "San Antonio Abad", new Station { Name = "San Antonio Abad", Latitude = 19.4196, Longitude = -99.1346 } },
            { "Chabacano", new Station { Name = "Chabacano", Latitude = 19.4084, Longitude = -99.1357 } },
            { "Viaducto", new Station { Name = "Viaducto", Latitude = 19.4009, Longitude = -99.1366 } },
            { "Xola", new Station { Name = "Xola", Latitude = 19.3952, Longitude = -99.1376 } },
            { "Villa de Cortés", new Station { Name = "Villa de Cortés", Latitude = 19.3877, Longitude = -99.1390 } },
            { "Nativitas", new Station { Name = "Nativitas", Latitude = 19.3794, Longitude = -99.1402 } },
            { "Portales", new Station { Name = "Portales", Latitude = 19.3702, Longitude = -99.1415 } },
            { "Ermita", new Station { Name = "Ermita", Latitude = 19.3618, Longitude = -99.1428 } },
            { "General Anaya", new Station { Name = "General Anaya", Latitude = 19.3531, Longitude = -99.1450 } },
            { "Tasqueña", new Station { Name = "Tasqueña", Latitude = 19.3440, Longitude = -99.1406 } },
            { "Indios Verdes", new Station { Name = "Indios Verdes", Latitude = 19.4950, Longitude = -99.1196 } },
            { "Deportivo 18 de Marzo", new Station { Name = "Deportivo 18 de Marzo", Latitude = 19.4843, Longitude = -99.1264 } },
            { "Potrero", new Station { Name = "Potrero", Latitude = 19.4770, Longitude = -99.1310 } },
            { "La Raza", new Station { Name = "La Raza", Latitude = 19.4703, Longitude = -99.1365 } },
            { "Tlatelolco", new Station { Name = "Tlatelolco", Latitude = 19.4556, Longitude = -99.1424 } },
            { "Guerrero", new Station { Name = "Guerrero", Latitude = 19.4457, Longitude = -99.1460 } },
            { "Juárez", new Station { Name = "Juárez", Latitude = 19.4293, Longitude = -99.1498 } },
            { "Niños Héroes", new Station { Name = "Niños Héroes", Latitude = 19.4196, Longitude = -99.1534 } },
            { "Hospital General", new Station { Name = "Hospital General", Latitude = 19.4126, Longitude = -99.1541 } },
            { "Centro Médico", new Station { Name = "Centro Médico", Latitude = 19.4067, Longitude = -99.1549 } },
            { "Etiopía / Plaza de la Transparencia", new Station { Name = "Etiopía / Plaza de la Transparencia", Latitude = 19.4006, Longitude = -99.1564 } },
            { "Eugenia", new Station { Name = "Eugenia", Latitude = 19.3925, Longitude = -99.1575 } },
            { "División del Norte", new Station { Name = "División del Norte", Latitude = 19.3845, Longitude = -99.1589 } },
            { "Zapata", new Station { Name = "Zapata", Latitude = 19.3708, Longitude = -99.1651 } },
            { "Coyoacán", new Station { Name = "Coyoacán", Latitude = 19.3620, Longitude = -99.1700 } },
            { "Viveros / Derechos Humanos", new Station { Name = "Viveros / Derechos Humanos", Latitude = 19.3536, Longitude = -99.1756 } },
            { "Miguel Ángel de Quevedo", new Station { Name = "Miguel Ángel de Quevedo", Latitude = 19.3445, Longitude = -99.1815 } },
            { "Copilco", new Station { Name = "Copilco", Latitude = 19.3358, Longitude = -99.1767 } },
            { "Universidad", new Station { Name = "Universidad", Latitude = 19.3244, Longitude = -99.1740 } },
            { "Martín Carrera", new Station { Name = "Martín Carrera", Latitude = 19.4861, Longitude = -99.1047 } },
            { "Talismán", new Station { Name = "Talismán", Latitude = 19.4738, Longitude = -99.1084 } },
            { "Bondojito", new Station { Name = "Bondojito", Latitude = 19.4638, Longitude = -99.1115 } },
            { "Consulado", new Station { Name = "Consulado", Latitude = 19.4524, Longitude = -99.1168 } },
            { "Canal del Norte", new Station { Name = "Canal del Norte", Latitude = 19.4453, Longitude = -99.1168 } },
            { "Morelos", new Station { Name = "Morelos", Latitude = 19.4386, Longitude = -99.1193 } },
            { "Fray Servando", new Station { Name = "Fray Servando", Latitude = 19.4215, Longitude = -99.1218 } },
            { "Jamaica", new Station { Name = "Jamaica", Latitude = 19.4108, Longitude = -99.1220 } },
            { "Santa Anita", new Station { Name = "Santa Anita", Latitude = 19.4036, Longitude = -99.1213 } },
            { "Politécnico", new Station { Name = "Politécnico", Latitude = 19.4998, Longitude = -99.1487 } },
            { "Instituto del Petróleo", new Station { Name = "Instituto del Petróleo", Latitude = 19.4915, Longitude = -99.1468 } },
            { "Autobuses del Norte", new Station { Name = "Autobuses del Norte", Latitude = 19.4804, Longitude = -99.1421 } },
            { "Misterios", new Station { Name = "Misterios", Latitude = 19.4621, Longitude = -99.1311 } },
            { "Valle Gómez", new Station { Name = "Valle Gómez", Latitude = 19.4566, Longitude = -99.1255 } },
            { "Eduardo Molina", new Station { Name = "Eduardo Molina", Latitude = 19.4505, Longitude = -99.1111 } },
            { "Aragón", new Station { Name = "Aragón", Latitude = 19.4489, Longitude = -99.1010 } },
            { "Oceanía", new Station { Name = "Oceanía", Latitude = 19.4462, Longitude = -99.0875 } },
            { "Terminal Aérea", new Station { Name = "Terminal Aérea", Latitude = 19.4336, Longitude = -99.0877 } },
            { "Hangares", new Station { Name = "Hangares", Latitude = 19.4246, Longitude = -99.0846 } },
            { "El Rosario", new Station { Name = "El Rosario", Latitude = 19.5048, Longitude = -99.2093 } },
            { "Tezozómoc", new Station { Name = "Tezozómoc", Latitude = 19.4954, Longitude = -99.1989 } },
            { "Azcapotzalco", new Station { Name = "Azcapotzalco", Latitude = 19.4910, Longitude = -99.1856 } },
            { "Ferrería / Arena CDMX", new Station { Name = "Ferrería / Arena CDMX", Latitude = 19.4903, Longitude = -99.1726 } },
            { "Norte 45", new Station { Name = "Norte 45", Latitude = 19.4889, Longitude = -99.1636 } },
            { "Vallejo", new Station { Name = "Vallejo", Latitude = 19.4903, Longitude = -99.1558 } },
            { "Lindavista", new Station { Name = "Lindavista", Latitude = 19.4872, Longitude = -99.1238 } },
            { "La Villa-Basílica", new Station { Name = "La Villa-Basílica", Latitude = 19.4826, Longitude = -99.1134 } },
            { "Aquiles Serdán", new Station { Name = "Aquiles Serdán", Latitude = 19.4904, Longitude = -99.1949 } },
            { "Camarones", new Station { Name = "Camarones", Latitude = 19.4791, Longitude = -99.1877 } },
            { "Refinería", new Station { Name = "Refinería", Latitude = 19.4700, Longitude = -99.1902 } },
            { "San Joaquín", new Station { Name = "San Joaquín", Latitude = 19.4454, Longitude = -99.1901 } },
            { "Polanco", new Station { Name = "Polanco", Latitude = 19.4337, Longitude = -99.1910 } },
            { "Auditorio", new Station { Name = "Auditorio", Latitude = 19.4248, Longitude = -99.1927 } },
            { "Constituyentes", new Station { Name = "Constituyentes", Latitude = 19.4118, Longitude = -99.1921 } },
            { "Tacubaya", new Station { Name = "Tacubaya", Latitude = 19.4032, Longitude = -99.1871 } },
            { "San Pedro de los Pinos", new Station { Name = "San Pedro de los Pinos", Latitude = 19.3906, Longitude = -99.1854 } },
            { "San Antonio", new Station { Name = "San Antonio", Latitude = 19.3835, Longitude = -99.1855 } },
            { "Mixcoac", new Station { Name = "Mixcoac", Latitude = 19.3757, Longitude = -99.1876 } },
            { "Barranca del Muerto", new Station { Name = "Barranca del Muerto", Latitude = 19.3615, Longitude = -99.1892 } },
            { "Garibaldi / Lagunilla", new Station { Name = "Garibaldi / Lagunilla", Latitude = 19.4446, Longitude = -99.1384 } },
            { "San Juan de Letrán", new Station { Name = "San Juan de Letrán", Latitude = 19.4309, Longitude = -99.1406 } },
            { "Doctores", new Station { Name = "Doctores", Latitude = 19.4215, Longitude = -99.1433 } },
            { "Obrera", new Station { Name = "Obrera", Latitude = 19.4132, Longitude = -99.1412 } },
            { "La Viga", new Station { Name = "La Viga", Latitude = 19.4077, Longitude = -99.1269 } },
            { "Coyuya", new Station { Name = "Coyuya", Latitude = 19.3996, Longitude = -99.1139 } },
            { "Iztacalco", new Station { Name = "Iztacalco", Latitude = 19.3886, Longitude = -99.1125 } },
            { "Apatlaco", new Station { Name = "Apatlaco", Latitude = 19.3784, Longitude = -99.1105 } },
            { "Aculco", new Station { Name = "Aculco", Latitude = 19.3713, Longitude = -99.1079 } },
            { "Escuadrón 201", new Station { Name = "Escuadrón 201", Latitude = 19.3644, Longitude = -99.1094 } },
            { "Atlalilco", new Station { Name = "Atlalilco", Latitude = 19.3563, Longitude = -99.1008 } },
            { "Iztapalapa", new Station { Name = "Iztapalapa", Latitude = 19.3577, Longitude = -99.0915 } },
            { "Cerro de la Estrella", new Station { Name = "Cerro de la Estrella", Latitude = 19.3558, Longitude = -99.0800 } },
            { "UAM-I", new Station { Name = "UAM-I", Latitude = 19.3513, Longitude = -99.0715 } },
            { "Constitución de 1917", new Station { Name = "Constitución de 1917", Latitude = 19.3462, Longitude = -99.0622 } },
            { "Patriotismo", new Station { Name = "Patriotismo", Latitude = 19.4034, Longitude = -99.1776 } },
            { "Chilpancingo", new Station { Name = "Chilpancingo", Latitude = 19.4065, Longitude = -99.1684 } },
            { "Lázaro Cárdenas", new Station { Name = "Lázaro Cárdenas", Latitude = 19.4072, Longitude = -99.1431 } },
            { "Mixiuhca", new Station { Name = "Mixiuhca", Latitude = 19.4094, Longitude = -99.1120 } },
            { "Velódromo", new Station { Name = "Velódromo", Latitude = 19.4087, Longitude = -99.1023 } },
            { "Ciudad Deportiva", new Station { Name = "Ciudad Deportiva", Latitude = 19.4083, Longitude = -99.0915 } },
            { "Puebla", new Station { Name = "Puebla", Latitude = 19.4070, Longitude = -99.0819 } },
            { "Agrícola Oriental", new Station { Name = "Agrícola Oriental", Latitude = 19.4044, Longitude = -99.0670 } },
            { "Canal de San Juan", new Station { Name = "Canal de San Juan", Latitude = 19.3985, Longitude = -99.0564 } },
            { "Tepalcates", new Station { Name = "Tepalcates", Latitude = 19.3925, Longitude = -99.0456 } },
            { "Guelatao", new Station { Name = "Guelatao", Latitude = 19.3863, Longitude = -99.0345 } },
            { "Peñón Viejo", new Station { Name = "Peñón Viejo", Latitude = 19.3788, Longitude = -99.0209 } },
            { "Acatitla", new Station { Name = "Acatitla", Latitude = 19.3711, Longitude = -99.0072 } },
            { "Santa Marta", new Station { Name = "Santa Marta", Latitude = 19.3652, Longitude = -98.9969 } },
            { "Los Reyes", new Station { Name = "Los Reyes", Latitude = 19.3607, Longitude = -98.9868 } },
            { "La Paz", new Station { Name = "La Paz", Latitude = 19.3504, Longitude = -98.9760 } },
            { "Ciudad Azteca", new Station { Name = "Ciudad Azteca", Latitude = 19.5346, Longitude = -99.0276 } },
            { "Plaza Aragón", new Station { Name = "Plaza Aragón", Latitude = 19.5288, Longitude = -99.0301 } },
            { "Olímpica", new Station { Name = "Olímpica", Latitude = 19.5210, Longitude = -99.0333 } },
            { "Ecatepec", new Station { Name = "Ecatepec", Latitude = 19.5144, Longitude = -99.0360 } },
            { "Múzquiz", new Station { Name = "Múzquiz", Latitude = 19.5019, Longitude = -99.0411 } },
            { "Río de los Remedios", new Station { Name = "Río de los Remedios", Latitude = 19.4911, Longitude = -99.0465 } },
            { "Impulsora", new Station { Name = "Impulsora", Latitude = 19.4868, Longitude = -99.0487 } },
            { "Nezahualcóyotl", new Station { Name = "Nezahualcóyotl", Latitude = 19.4780, Longitude = -99.0531 } },
            { "Villa de Aragón", new Station { Name = "Villa de Aragón", Latitude = 19.4705, Longitude = -99.0571 } },
            { "Bosque de Aragón", new Station { Name = "Bosque de Aragón", Latitude = 19.4631, Longitude = -99.0605 } },
            { "Deportivo Oceanía", new Station { Name = "Deportivo Oceanía", Latitude = 19.4518, Longitude = -99.0790 } },
            { "Romero Rubio", new Station { Name = "Romero Rubio", Latitude = 19.4408, Longitude = -99.0949 } },
            { "Ricardo Flores Magón", new Station { Name = "Ricardo Flores Magón", Latitude = 19.4368, Longitude = -99.1037 } },
            { "Tepito", new Station { Name = "Tepito", Latitude = 19.4421, Longitude = -99.1235 } },
            { "Lagunilla", new Station { Name = "Lagunilla", Latitude = 19.4430, Longitude = -99.1325 } },
            { "Buenavista", new Station { Name = "Buenavista", Latitude = 19.4467, Longitude = -99.1527 } },
            { "Insurgentes Sur", new Station { Name = "Insurgentes Sur", Latitude = 19.3733, Longitude = -99.1783 } },
            { "Hospital 20 de Noviembre", new Station { Name = "Hospital 20 de Noviembre", Latitude = 19.3717, Longitude = -99.1725 } },
            { "Parque de los Venados", new Station { Name = "Parque de los Venados", Latitude = 19.3697, Longitude = -99.1573 } },
            { "Eje Central", new Station { Name = "Eje Central", Latitude = 19.3666, Longitude = -99.1506 } },
            { "Mexicaltzingo", new Station { Name = "Mexicaltzingo", Latitude = 19.3596, Longitude = -99.1222 } },
            { "Culhuacán", new Station { Name = "Culhuacán", Latitude = 19.3472, Longitude = -99.1107 } },
            { "San Andrés Tomatlán", new Station { Name = "San Andrés Tomatlán", Latitude = 19.3389, Longitude = -99.1091 } },
            { "Lomas Estrella", new Station { Name = "Lomas Estrella", Latitude = 19.3295, Longitude = -99.0962 } },
            { "Calle 11", new Station { Name = "Calle 11", Latitude = 19.3207, Longitude = -99.0838 } },
            { "Periférico Oriente", new Station { Name = "Periférico Oriente", Latitude = 19.3159, Longitude = -99.0703 } },
            { "Tezonco", new Station { Name = "Tezonco", Latitude = 19.3087, Longitude = -99.0547 } },
            { "Olivos", new Station { Name = "Olivos", Latitude = 19.3038, Longitude = -99.0439 } },
            { "Nopalera", new Station { Name = "Nopalera", Latitude = 19.3010, Longitude = -99.0345 } },
            { "Zapotitlán", new Station { Name = "Zapotitlán", Latitude = 19.2969, Longitude = -99.0242 } },
            { "Tlaltenco", new Station { Name = "Tlaltenco", Latitude = 19.2903, Longitude = -99.0162 } },
            { "Tláhuac", new Station { Name = "Tláhuac", Latitude = 19.2866, Longitude = -99.0145 } },
        };

        /// <summary>
        /// A list containing definitions for each metro line, including its name and the stations it serves.
        /// </summary>
        public static List<MetroLine> Lines = new List<MetroLine>
        {
            new MetroLine { Name = "Línea 1", Stations = new List<string> { "Observatorio", "Tacubaya", "Juanacatlán", "Chapultepec", "Sevilla", "Insurgentes", "Cuauhtémoc", "Balderas", "Salto del Agua", "Isabel la Católica", "Pino Suárez", "Merced", "Candelaria", "San Lázaro", "Moctezuma", "Balbuena", "Blvd. Puerto Aéreo", "Gómez Farías", "Zaragoza", "Pantitlán" } },
            new MetroLine { Name = "Línea 2", Stations = new List<string> { "Cuatro Caminos", "Panteones", "Tacuba", "Cuitláhuac", "Popotla", "Colegio Militar", "Normal", "San Cosme", "Revolución", "Hidalgo", "Bellas Artes", "Allende", "Zócalo", "Pino Suárez", "Chabacano", "Viaducto", "Xola", "Villa de Cortés", "Nativitas", "Portales", "Ermita", "General Anaya", "Tasqueña" } },
            new MetroLine { Name = "Línea 3", Stations = new List<string> { "Indios Verdes", "Deportivo 18 de Marzo", "Potrero", "La Raza", "Tlatelolco", "Guerrero", "Hidalgo", "Juárez", "Balderas", "Niños Héroes", "Hospital General", "Centro Médico", "Etiopía / Plaza de la Transparencia", "Eugenia", "División del Norte", "Zapata", "Coyoacán", "Viveros / Derechos Humanos", "Miguel Ángel de Quevedo", "Copilco", "Universidad" } },
            new MetroLine { Name = "Línea 4", Stations = new List<string> { "Martín Carrera", "Talismán", "Bondojito", "Consulado", "Canal del Norte", "Morelos", "Candelaria", "Fray Servando", "Jamaica", "Santa Anita" } },
            new MetroLine { Name = "Línea 5", Stations = new List<string> { "Politécnico", "Instituto del Petróleo", "Autobuses del Norte", "La Raza", "Misterios", "Valle Gómez", "Consulado", "Eduardo Molina", "Aragón", "Oceanía", "Terminal Aérea", "Hangares", "Pantitlán" } },
            new MetroLine { Name = "Línea 6", Stations = new List<string> { "El Rosario", "Tezozómoc", "Azcapotzalco", "Ferrería / Arena CDMX", "Norte 45", "Vallejo", "Instituto del Petróleo", "Lindavista", "Deportivo 18 de Marzo", "La Villa-Basílica", "Martín Carrera" } },
            new MetroLine { Name = "Línea 7", Stations = new List<string> { "El Rosario", "Aquiles Serdán", "Camarones", "Refinería", "Tacuba", "San Joaquín", "Polanco", "Auditorio", "Constituyentes", "Tacubaya", "San Pedro de los Pinos", "San Antonio", "Mixcoac", "Barranca del Muerto" } },
            new MetroLine { Name = "Línea 8", Stations = new List<string> { "Garibaldi / Lagunilla", "Bellas Artes", "San Juan de Letrán", "Salto del Agua", "Obrera", "Chabacano", "La Viga", "Coyuya", "Iztacalco", "Apatlaco", "Aculco", "Escuadrón 201", "Atlalilco", "Iztapalapa", "Cerro de la Estrella", "UAM-I", "Constitución de 1917" } },
            new MetroLine { Name = "Línea 9", Stations = new List<string> { "Tacubaya", "Patriotismo", "Chilpancingo", "Centro Médico", "Lázaro Cárdenas", "Chabacano", "Jamaica", "Mixiuhca", "Velódromo", "Ciudad Deportiva", "Puebla", "Pantitlán" } },
            new MetroLine { Name = "Línea A", Stations = new List<string> { "Pantitlán", "Agrícola Oriental", "Canal de San Juan", "Tepalcates", "Guelatao", "Peñón Viejo", "Acatitla", "Santa Marta", "Los Reyes", "La Paz" } },
            new MetroLine { Name = "Línea B", Stations = new List<string> { "Buenavista", "Guerrero", "Garibaldi / Lagunilla", "Lagunilla", "Tepito", "Morelos", "San Lázaro", "Ricardo Flores Magón", "Romero Rubio", "Oceanía", "Deportivo Oceanía", "Bosque de Aragón", "Villa de Aragón", "Nezahualcóyotl", "Impulsora", "Río de los Remedios", "Múzquiz", "Ecatepec", "Olímpica", "Plaza Aragón", "Ciudad Azteca" } },
            new MetroLine { Name = "Línea 12", Stations = new List<string> { "Mixcoac", "Insurgentes Sur", "Hospital 20 de Noviembre", "Zapata", "Parque de los Venados", "Eje Central", "Ermita", "Mexicaltzingo", "Atlalilco", "Culhuacán", "San Andrés Tomatlán", "Lomas Estrella", "Calle 11", "Periférico Oriente", "Tezonco", "Olivos", "Nopalera", "Zapotitlán", "Tlaltenco", "Tláhuac" } }
        };
    }
}
