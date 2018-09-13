using System.Collections.Generic;

/* 
 *   Autor/Author: Pedro Lucas de Oliveira Cabral 
 *   GitHub: https://github.com/DoisLucas
 *   Data/Date: 01/02/2018
 */

public class AddPerguntas
{
	public static List<Perguntas> perguntas_exatas = new List<Perguntas>();
	public static List<Perguntas> perguntas_humanas = new List<Perguntas>();
	public static List<Perguntas> perguntas_bio = new List<Perguntas>();
	public static List<Perguntas> perguntas_bagian4 = new List<Perguntas>();

	public static List<Perguntas> getPerguntas_bagian4()
	{
		return perguntas_bagian4;
	}
		
	public static List<Perguntas> getPerguntas_exatas()
	{
		return perguntas_exatas;
	}

	public static List<Perguntas> getPerguntas_humanas()
	{
		return perguntas_humanas;
	}

	public static List<Perguntas> getPerguntas_bio()
	{
		return perguntas_bio;
	}

	public static void Add_exatas()
	{
		if (perguntas_exatas.Count == 0)
		{
			Perguntas p1 = new Perguntas("Apa nama Senjata daerah yang berasal dari Papua ini?", 1, "Busur Panah", "Keris Pasatimpo", "Parang Salawaku", "Perisai Talawang", 10);
			perguntas_exatas.Add(p1);

			Perguntas p2 = new Perguntas("Disebut apakah rumah tradisional ini?", 3, "Tambi", "Panjang", "Honai", "Baileo", 10);
			perguntas_exatas.Add(p2);

			Perguntas p3 = new Perguntas("Apakah nama pakaian adat ini?", 2, "Cele", "Ewer", "Koje dan Nggembe", "Baba dan Bibinge", 10);
			perguntas_exatas.Add(p3);

			Perguntas p4 = new Perguntas("Nama Alat Musik ini adalah?", 3, "Arababu", "Kakula", "Tifa", "Sape", 10);
			perguntas_exatas.Add(p4);
		}
	}

	public static void Add_humanas()
	{
		if (perguntas_humanas.Count == 0)
		{
			Perguntas p1 = new Perguntas("Apa nama Senjata daerah yang berasal dari Maluku ini?", 1, "Parang Salawaku", "Keris Pasatimpo", "Busur Panah", "Perisai Talawang", 10);
			perguntas_humanas.Add(p1);

			Perguntas p2 = new Perguntas("Disebut apakah rumah tradisional ini?", 2, "Panjang", "Baileo", "Tambi", "Honai", 10);
			perguntas_humanas.Add(p2);

			Perguntas p3 = new Perguntas("Apakah nama pakaian adat ini?", 3, "Ewer", "Koje dan Nggembe", "Cele", "Baba dan Bibinge", 10);
			perguntas_humanas.Add(p3);

			Perguntas p4 = new Perguntas("Nama Alat Musik ini adalah?", 4, "Kakula", "Tifa", "Sape", "Arababu", 10);
			perguntas_humanas.Add(p4);
		}
	}

	public static void Add_bio()
	{
		if (perguntas_bio.Count == 0)
		{
			Perguntas p1 = new Perguntas("Apa nama Senjata daerah yang berasal dari Sulawesi Tengah ini?", 2, "Perisai Talawangan", "Keris Pasatimpo", "Busur Panah", "Parang Salawaku", 10);
			perguntas_bio.Add(p1);

			Perguntas p2 = new Perguntas("Disebut apakah rumah tradisional ini?", 1, "Tambi", "Panjang", "Honai", "Baileo", 10);
			perguntas_bio.Add(p2);

			Perguntas p3 = new Perguntas("Apakah nama pakaian adat ini?", 3, "Cele", "Ewer", "Koje dan Nggembe", "Baba dan Bibinge", 10);
			perguntas_bio.Add(p3);

			Perguntas p4 = new Perguntas("Nama Alat Musik ini adalah?", 4, "Sape", "Arababu", "Tifa", "Kakula", 10);
			perguntas_bio.Add(p4);
		}
	}

	public static void Add_bagian4()
	{
		if (perguntas_bagian4.Count == 0)
		{
			Perguntas p1 = new Perguntas("Apa nama Senjata daerah yang berasal dari Kalimantan Barat ini?", 1, "Perisai Talawang", "Busur Panah", "Parang Salawaku", "Keris Pasatimpo", 10);
			perguntas_bagian4.Add(p1);

			Perguntas p2 = new Perguntas("Disebut apakah rumah tradisional ini?", 3, "Honai", "Tambi", "Panjang", "Baileo", 10);
			perguntas_bagian4.Add(p2);

			Perguntas p3 = new Perguntas("Apakah nama pakaian adat ini?", 2, "Ewer", "Baba dan Bibinge", "Koje dan Nggembe", "Cele", 10);
			perguntas_bagian4.Add(p3);

			Perguntas p4 = new Perguntas("Nama Alat Musik ini adalah?", 3, "Arababu", "Kakula", "Sape", "Tifa", 10);
			perguntas_bagian4.Add(p4);
		}
	}
}
