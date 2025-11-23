using MAI.Components.Layout;

namespace MAI.Models;
public class MetroStationsStatic
{
    public static List<OpenStreetMap.MapMarker> MetroStations = new()
    {
        // --- LÍNEA 1 (Observatorio - Pantitlán) ---
        new() { Title = "Observatorio", Latitude = 19.3982, Longitude = -99.2004 },
        new() { Title = "Tacubaya", Latitude = 19.4032, Longitude = -99.1871 },
        new() { Title = "Juanacatlán", Latitude = 19.4129, Longitude = -99.1821 },
        new() { Title = "Chapultepec", Latitude = 19.4206, Longitude = -99.1762 },
        new() { Title = "Sevilla", Latitude = 19.4219, Longitude = -99.1706 },
        new() { Title = "Insurgentes", Latitude = 19.4233, Longitude = -99.1631 },
        new() { Title = "Cuauhtémoc", Latitude = 19.4258, Longitude = -99.1546 },
        new() { Title = "Balderas", Latitude = 19.4274, Longitude = -99.1491 },
        new() { Title = "Salto del Agua", Latitude = 19.4266, Longitude = -99.1423 },
        new() { Title = "Isabel la Católica", Latitude = 19.4265, Longitude = -99.1376 },
        new() { Title = "Pino Suárez", Latitude = 19.4259, Longitude = -99.1330 },
        new() { Title = "Merced", Latitude = 19.4256, Longitude = -99.1245 },
        new() { Title = "Candelaria", Latitude = 19.4290, Longitude = -99.1196 },
        new() { Title = "San Lázaro", Latitude = 19.4303, Longitude = -99.1148 },
        new() { Title = "Moctezuma", Latitude = 19.4276, Longitude = -99.1097 },
        new() { Title = "Balbuena", Latitude = 19.4237, Longitude = -99.1027 },
        new() { Title = "Blvd. Puerto Aéreo", Latitude = 19.4197, Longitude = -99.0960 },
        new() { Title = "Gómez Farías", Latitude = 19.4165, Longitude = -99.0904 },
        new() { Title = "Zaragoza", Latitude = 19.4122, Longitude = -99.0824 },
        new() { Title = "Pantitlán", Latitude = 19.4153, Longitude = -99.0723 },

        // --- LÍNEA 2 (Cuatro Caminos - Tasqueña) ---
        new() { Title = "Cuatro Caminos", Latitude = 19.4594, Longitude = -99.2158 },
        new() { Title = "Panteones", Latitude = 19.4586, Longitude = -99.2031 },
        new() { Title = "Tacuba", Latitude = 19.4586, Longitude = -99.1884 },
        new() { Title = "Cuitláhuac", Latitude = 19.4574, Longitude = -99.1750 },
        new() { Title = "Popotla", Latitude = 19.4520, Longitude = -99.1692 },
        new() { Title = "Colegio Militar", Latitude = 19.4484, Longitude = -99.1720 },
        new() { Title = "Normal", Latitude = 19.4443, Longitude = -99.1673 },
        new() { Title = "San Cosme", Latitude = 19.4413, Longitude = -99.1611 },
        new() { Title = "Revolución", Latitude = 19.4396, Longitude = -99.1546 },
        new() { Title = "Hidalgo", Latitude = 19.4374, Longitude = -99.1473 },
        new() { Title = "Bellas Artes", Latitude = 19.4362, Longitude = -99.1418 },
        new() { Title = "Allende", Latitude = 19.4353, Longitude = -99.1373 },
        new() { Title = "Zócalo", Latitude = 19.4330, Longitude = -99.1326 },
        new() { Title = "San Antonio Abad", Latitude = 19.4196, Longitude = -99.1346 },
        new() { Title = "Chabacano", Latitude = 19.4084, Longitude = -99.1357 },
        new() { Title = "Viaducto", Latitude = 19.4009, Longitude = -99.1366 },
        new() { Title = "Xola", Latitude = 19.3952, Longitude = -99.1376 },
        new() { Title = "Villa de Cortés", Latitude = 19.3877, Longitude = -99.1390 },
        new() { Title = "Nativitas", Latitude = 19.3794, Longitude = -99.1402 },
        new() { Title = "Portales", Latitude = 19.3702, Longitude = -99.1415 },
        new() { Title = "Ermita", Latitude = 19.3618, Longitude = -99.1428 },
        new() { Title = "General Anaya", Latitude = 19.3531, Longitude = -99.1450 },
        new() { Title = "Tasqueña", Latitude = 19.3440, Longitude = -99.1406 },

        // --- LÍNEA 3 (Indios Verdes - Universidad) ---
        new() { Title = "Indios Verdes", Latitude = 19.4950, Longitude = -99.1196 },
        new() { Title = "Deportivo 18 de Marzo", Latitude = 19.4843, Longitude = -99.1264 },
        new() { Title = "Potrero", Latitude = 19.4770, Longitude = -99.1310 },
        new() { Title = "La Raza", Latitude = 19.4703, Longitude = -99.1365 },
        new() { Title = "Tlatelolco", Latitude = 19.4556, Longitude = -99.1424 },
        new() { Title = "Guerrero", Latitude = 19.4457, Longitude = -99.1460 },
        // Hidalgo y Balderas ya existen
        new() { Title = "Juárez", Latitude = 19.4293, Longitude = -99.1498 },
        new() { Title = "Niños Héroes", Latitude = 19.4196, Longitude = -99.1534 },
        new() { Title = "Hospital General", Latitude = 19.4126, Longitude = -99.1541 },
        new() { Title = "Centro Médico", Latitude = 19.4067, Longitude = -99.1549 },
        new() { Title = "Etiopía / Plaza de la Transparencia", Latitude = 19.4006, Longitude = -99.1564 },
        new() { Title = "Eugenia", Latitude = 19.3925, Longitude = -99.1575 },
        new() { Title = "División del Norte", Latitude = 19.3845, Longitude = -99.1589 },
        new() { Title = "Zapata", Latitude = 19.3708, Longitude = -99.1651 },
        new() { Title = "Coyoacán", Latitude = 19.3620, Longitude = -99.1700 },
        new() { Title = "Viveros / Derechos Humanos", Latitude = 19.3536, Longitude = -99.1756 },
        new() { Title = "Miguel Ángel de Quevedo", Latitude = 19.3445, Longitude = -99.1815 },
        new() { Title = "Copilco", Latitude = 19.3358, Longitude = -99.1767 },
        new() { Title = "Universidad", Latitude = 19.3244, Longitude = -99.1740 },

        // --- LÍNEA 4 (Martín Carrera - Santa Anita) ---
        new() { Title = "Martín Carrera", Latitude = 19.4861, Longitude = -99.1047 },
        new() { Title = "Talismán", Latitude = 19.4738, Longitude = -99.1084 },
        new() { Title = "Bondojito", Latitude = 19.4638, Longitude = -99.1115 },
        new() { Title = "Consulado", Latitude = 19.4524, Longitude = -99.1168 },
        new() { Title = "Canal del Norte", Latitude = 19.4453, Longitude = -99.1168 },
        new() { Title = "Morelos", Latitude = 19.4386, Longitude = -99.1193 },
        // Candelaria y San Lázaro ya existen
        new() { Title = "Fray Servando", Latitude = 19.4215, Longitude = -99.1218 },
        new() { Title = "Jamaica", Latitude = 19.4108, Longitude = -99.1220 },
        new() { Title = "Santa Anita", Latitude = 19.4036, Longitude = -99.1213 },

        // --- LÍNEA 5 (Politécnico - Pantitlán) ---
        new() { Title = "Politécnico", Latitude = 19.4998, Longitude = -99.1487 },
        new() { Title = "Instituto del Petróleo", Latitude = 19.4915, Longitude = -99.1468 },
        new() { Title = "Autobuses del Norte", Latitude = 19.4804, Longitude = -99.1421 },
        // La Raza y Consulado ya existen
        new() { Title = "Misterios", Latitude = 19.4621, Longitude = -99.1311 },
        new() { Title = "Valle Gómez", Latitude = 19.4566, Longitude = -99.1255 },
        new() { Title = "Eduardo Molina", Latitude = 19.4505, Longitude = -99.1111 },
        new() { Title = "Aragón", Latitude = 19.4489, Longitude = -99.1010 },
        new() { Title = "Oceanía", Latitude = 19.4462, Longitude = -99.0875 },
        new() { Title = "Terminal Aérea", Latitude = 19.4336, Longitude = -99.0877 },
        new() { Title = "Hangares", Latitude = 19.4246, Longitude = -99.0846 },
        // Pantitlán ya existe

        // --- LÍNEA 6 (El Rosario - Martín Carrera) ---
        new() { Title = "El Rosario", Latitude = 19.5048, Longitude = -99.2093 },
        new() { Title = "Tezozómoc", Latitude = 19.4954, Longitude = -99.1989 },
        new() { Title = "Azcapotzalco", Latitude = 19.4910, Longitude = -99.1856 },
        new() { Title = "Ferrería / Arena CDMX", Latitude = 19.4903, Longitude = -99.1726 },
        new() { Title = "Norte 45", Latitude = 19.4889, Longitude = -99.1636 },
        new() { Title = "Vallejo", Latitude = 19.4903, Longitude = -99.1558 },
        // Instituto del Petróleo ya existe
        new() { Title = "Lindavista", Latitude = 19.4872, Longitude = -99.1238 },
        // Deportivo 18 de Marzo ya existe
        new() { Title = "La Villa-Basílica", Latitude = 19.4826, Longitude = -99.1134 },
        // Martín Carrera ya existe

        // --- LÍNEA 7 (El Rosario - Barranca del Muerto) ---
        // El Rosario ya existe
        new() { Title = "Aquiles Serdán", Latitude = 19.4904, Longitude = -99.1949 },
        new() { Title = "Camarones", Latitude = 19.4791, Longitude = -99.1877 },
        new() { Title = "Refinería", Latitude = 19.4700, Longitude = -99.1902 },
        // Tacuba ya existe
        new() { Title = "San Joaquín", Latitude = 19.4454, Longitude = -99.1901 },
        new() { Title = "Polanco", Latitude = 19.4337, Longitude = -99.1910 },
        new() { Title = "Auditorio", Latitude = 19.4248, Longitude = -99.1927 },
        new() { Title = "Constituyentes", Latitude = 19.4118, Longitude = -99.1921 },
        // Tacubaya ya existe
        new() { Title = "San Pedro de los Pinos", Latitude = 19.3906, Longitude = -99.1854 },
        new() { Title = "San Antonio", Latitude = 19.3835, Longitude = -99.1855 },
        new() { Title = "Mixcoac", Latitude = 19.3757, Longitude = -99.1876 },
        new() { Title = "Barranca del Muerto", Latitude = 19.3615, Longitude = -99.1892 },

        // --- LÍNEA 8 (Garibaldi - Constitución de 1917) ---
        new() { Title = "Garibaldi / Lagunilla", Latitude = 19.4446, Longitude = -99.1384 },
        // Bellas Artes, Salto del Agua, Chabacano y Santa Anita ya existen
        new() { Title = "San Juan de Letrán", Latitude = 19.4309, Longitude = -99.1406 },
        new() { Title = "Doctores", Latitude = 19.4215, Longitude = -99.1433 },
        new() { Title = "Obrera", Latitude = 19.4132, Longitude = -99.1412 },
        new() { Title = "La Viga", Latitude = 19.4077, Longitude = -99.1269 },
        new() { Title = "Coyuya", Latitude = 19.3996, Longitude = -99.1139 },
        new() { Title = "Iztacalco", Latitude = 19.3886, Longitude = -99.1125 },
        new() { Title = "Apatlaco", Latitude = 19.3784, Longitude = -99.1105 },
        new() { Title = "Aculco", Latitude = 19.3713, Longitude = -99.1079 },
        new() { Title = "Escuadrón 201", Latitude = 19.3644, Longitude = -99.1094 },
        new() { Title = "Atlalilco", Latitude = 19.3563, Longitude = -99.1008 },
        new() { Title = "Iztapalapa", Latitude = 19.3577, Longitude = -99.0915 },
        new() { Title = "Cerro de la Estrella", Latitude = 19.3558, Longitude = -99.0800 },
        new() { Title = "UAM-I", Latitude = 19.3513, Longitude = -99.0715 },
        new() { Title = "Constitución de 1917", Latitude = 19.3462, Longitude = -99.0622 },

        // --- LÍNEA 9 (Tacubaya - Pantitlán) ---
        // Tacubaya, Centro Médico, Chabacano, Jamaica y Pantitlán ya existen
        new() { Title = "Patriotismo", Latitude = 19.4034, Longitude = -99.1776 },
        new() { Title = "Chilpancingo", Latitude = 19.4065, Longitude = -99.1684 },
        new() { Title = "Lázaro Cárdenas", Latitude = 19.4072, Longitude = -99.1431 },
        new() { Title = "Mixiuhca", Latitude = 19.4094, Longitude = -99.1120 },
        new() { Title = "Velódromo", Latitude = 19.4087, Longitude = -99.1023 },
        new() { Title = "Ciudad Deportiva", Latitude = 19.4083, Longitude = -99.0915 },
        new() { Title = "Puebla", Latitude = 19.4070, Longitude = -99.0819 },

        // --- LÍNEA A (Pantitlán - La Paz) ---
        // Pantitlán ya existe
        new() { Title = "Agrícola Oriental", Latitude = 19.4044, Longitude = -99.0670 },
        new() { Title = "Canal de San Juan", Latitude = 19.3985, Longitude = -99.0564 },
        new() { Title = "Tepalcates", Latitude = 19.3925, Longitude = -99.0456 },
        new() { Title = "Guelatao", Latitude = 19.3863, Longitude = -99.0345 },
        new() { Title = "Peñón Viejo", Latitude = 19.3788, Longitude = -99.0209 },
        new() { Title = "Acatitla", Latitude = 19.3711, Longitude = -99.0072 },
        new() { Title = "Santa Marta", Latitude = 19.3652, Longitude = -98.9969 },
        new() { Title = "Los Reyes", Latitude = 19.3607, Longitude = -98.9868 },
        new() { Title = "La Paz", Latitude = 19.3504, Longitude = -98.9760 },

        // --- LÍNEA B (Ciudad Azteca - Buenavista) ---
        new() { Title = "Ciudad Azteca", Latitude = 19.5346, Longitude = -99.0276 },
        new() { Title = "Plaza Aragón", Latitude = 19.5288, Longitude = -99.0301 },
        new() { Title = "Olímpica", Latitude = 19.5210, Longitude = -99.0333 },
        new() { Title = "Ecatepec", Latitude = 19.5144, Longitude = -99.0360 },
        new() { Title = "Múzquiz", Latitude = 19.5019, Longitude = -99.0411 },
        new() { Title = "Río de los Remedios", Latitude = 19.4911, Longitude = -99.0465 },
        new() { Title = "Impulsora", Latitude = 19.4868, Longitude = -99.0487 },
        new() { Title = "Nezahualcóyotl", Latitude = 19.4780, Longitude = -99.0531 },
        new() { Title = "Villa de Aragón", Latitude = 19.4705, Longitude = -99.0571 },
        new() { Title = "Bosque de Aragón", Latitude = 19.4631, Longitude = -99.0605 },
        new() { Title = "Deportivo Oceanía", Latitude = 19.4518, Longitude = -99.0790 },
        // Oceanía, San Lázaro, Morelos, Garibaldi y Guerrero ya existen
        new() { Title = "Romero Rubio", Latitude = 19.4408, Longitude = -99.0949 },
        new() { Title = "R. Flores Magón", Latitude = 19.4368, Longitude = -99.1037 },
        new() { Title = "Tepito", Latitude = 19.4421, Longitude = -99.1235 },
        new() { Title = "Lagunilla", Latitude = 19.4430, Longitude = -99.1325 },
        new() { Title = "Buenavista", Latitude = 19.4467, Longitude = -99.1527 },

        // --- LÍNEA 12 (Mixcoac - Tláhuac) ---
        // Mixcoac, Zapata, Ermita y Atlalilco ya existen
        new() { Title = "Insurgentes Sur", Latitude = 19.3733, Longitude = -99.1783 },
        new() { Title = "Hospital 20 de Noviembre", Latitude = 19.3717, Longitude = -99.1725 },
        new() { Title = "Parque de los Venados", Latitude = 19.3697, Longitude = -99.1573 },
        new() { Title = "Eje Central", Latitude = 19.3666, Longitude = -99.1506 },
        new() { Title = "Mexicaltzingo", Latitude = 19.3596, Longitude = -99.1222 },
        new() { Title = "Culhuacán", Latitude = 19.3472, Longitude = -99.1107 },
        new() { Title = "San Andrés Tomatlán", Latitude = 19.3389, Longitude = -99.1091 },
        new() { Title = "Lomas Estrella", Latitude = 19.3295, Longitude = -99.0962 },
        new() { Title = "Calle 11", Latitude = 19.3207, Longitude = -99.0838 },
        new() { Title = "Periférico Oriente", Latitude = 19.3159, Longitude = -99.0703 },
        new() { Title = "Tezonco", Latitude = 19.3087, Longitude = -99.0547 },
        new() { Title = "Olivos", Latitude = 19.3038, Longitude = -99.0439 },
        new() { Title = "Nopalera", Latitude = 19.3010, Longitude = -99.0345 },
        new() { Title = "Zapotitlán", Latitude = 19.2969, Longitude = -99.0242 },
        new() { Title = "Tlaltenco", Latitude = 19.2903, Longitude = -99.0162 },
        new() { Title = "Tláhuac", Latitude = 19.2866, Longitude = -99.0145 },
    };
}