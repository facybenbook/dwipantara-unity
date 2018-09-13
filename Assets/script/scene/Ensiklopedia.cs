using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dwipantara {

public class Ensiklopedia : MonoBehaviour {

	public GameObject [] item, kunci, button;
	public GameObject desc;
	public Text desctext;
	public GameObject animasi;
	Animator botaoanim;
	private int status = 0, hal = 0;

	void Update () {
			if(hal > 2 || hal < 0) {
				hal = 0;
			}

			if(status==0 && hal==0) {
				kunci[0].gameObject.SetActive (false);
				button [1].gameObject.SetActive (false);
				button [0].gameObject.SetActive (true);
				item [0].gameObject.SetActive (true);
				item [2].gameObject.SetActive (false);
				item [4].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (false);
			}

			if(status==0 && hal==0) {
				kunci[1].gameObject.SetActive (false);
				item [1].gameObject.SetActive (true);
				item [5].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (false);
			}

			if(status==0 && hal==1) {
				kunci[0].gameObject.SetActive (false);
				button [0].gameObject.SetActive (false);
				button [1].gameObject.SetActive (true);
				item [0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (false);
				item [4].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				item [8].gameObject.SetActive (true);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (false);
			}

			if(status==0 && hal==1) {
				kunci[1].gameObject.SetActive (false);
				item [1].gameObject.SetActive (false);
				item [5].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				item [9].gameObject.SetActive (true);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (false);
			}

			if(status==1 && hal==0) {
				button [1].gameObject.SetActive (false);
				button [0].gameObject.SetActive (true);
				item [0].gameObject.SetActive (false);
				item [4].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				kunci[0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (true);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (false);
			}

			if(status==1 && hal==0) {
				item [1].gameObject.SetActive (false);
				item [5].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				kunci[1].gameObject.SetActive (false);
				item [3].gameObject.SetActive (true);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (false);
			}

			if(status==1 && hal==1) {
				item [0].gameObject.SetActive (false);
				button [0].gameObject.SetActive (false);
				button [1].gameObject.SetActive (true);
				item [4].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				kunci[0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (false);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (true);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (false);
			}

			if(status==1 && hal==1) {
				item [1].gameObject.SetActive (false);
				item [5].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				kunci[1].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (true);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (false);
			}

			if(status==2 && hal==0) {
				button [1].gameObject.SetActive (false);
				button [0].gameObject.SetActive (true);
				item [0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				kunci[0].gameObject.SetActive (false);
				item [4].gameObject.SetActive (true);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (false);
			}

			if(status==2 && hal==0) {
				item [1].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				kunci[1].gameObject.SetActive (false);
				item [5].gameObject.SetActive (true);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (false);
			}

			if(status==2 && hal==1) {
				button [0].gameObject.SetActive (false);
				button [1].gameObject.SetActive (true);
				item [0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				kunci[0].gameObject.SetActive (false);
				item [4].gameObject.SetActive (false);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (true);
				item [14].gameObject.SetActive (false);
			}

			if(status==2 && hal==1) {
				item [1].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				kunci[1].gameObject.SetActive (false);
				item [5].gameObject.SetActive (false);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (true);
				item [15].gameObject.SetActive (false);
			}

			if(status==3 && hal==0) {
				button [1].gameObject.SetActive (false);
				button [0].gameObject.SetActive (true);
				item [0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (false);
				item [4].gameObject.SetActive (false);
				kunci[0].gameObject.SetActive (false);
				item [6].gameObject.SetActive (true);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (false);
			}

			if(status==3 && hal==0) {
				item [1].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [5].gameObject.SetActive (false);
				kunci[1].gameObject.SetActive (false);
				item [7].gameObject.SetActive (true);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (false);
			}

			if(status==3 && hal==1) {
				button [0].gameObject.SetActive (false);
				button [1].gameObject.SetActive (true);
				item [0].gameObject.SetActive (false);
				item [2].gameObject.SetActive (false);
				item [4].gameObject.SetActive (false);
				kunci[0].gameObject.SetActive (false);
				item [6].gameObject.SetActive (false);
				item [8].gameObject.SetActive (false);
				item [10].gameObject.SetActive (false);
				item [12].gameObject.SetActive (false);
				item [14].gameObject.SetActive (true);
			}

			if(status==3 && hal==1) {
				item [1].gameObject.SetActive (false);
				item [3].gameObject.SetActive (false);
				item [5].gameObject.SetActive (false);
				kunci[1].gameObject.SetActive (false);
				item [7].gameObject.SetActive (false);
				item [9].gameObject.SetActive (false);
				item [11].gameObject.SetActive (false);
				item [13].gameObject.SetActive (false);
				item [15].gameObject.SetActive (true);
			}

			botaoanim = animasi.GetComponent<Animator> ();
	}

	public void ResetKoleksi () {
			PlayerPrefs.DeleteKey("Awal");
			PlayerPrefs.DeleteKey("BusurPanah");
			PlayerPrefs.DeleteKey("Honai");
			PlayerPrefs.DeleteKey("ParangSalawaku");
			PlayerPrefs.DeleteKey("KerisPasatimpo");
			PlayerPrefs.DeleteKey("PerisaiTalawang");
			SceneManager.LoadScene("Ensiklopedia");
	}

	public void desctutup () {
			desc.gameObject.SetActive (false);
	}

	public void descbp () {
			desc.gameObject.SetActive (true);
			desctext.text = "Busur dan Panah adalah senjata tradisional yang paling populer dan sering digunakan dari beragam varian senjata tradisional Papua. Senjata ini umumnya digunakan untuk berburu babi dan hewan liar lainnya. Selain itu, seringnya konflik antar kelompok yang terjadi membuat senjata ini juga kerap digunakan untuk berperang. Busur terbuat dari kayu rumi dengan seutas tali dari rotan. Sementara anak panahnya terbuat dari kayu dengan mata panah dari tulang hewan yang diruncingkan. Mata panah ini biasanya dibubuhi cairan racun dari getah tumbuhan hutan untuk menambah efek luka.";
	}

	public void descps () {
			desc.gameObject.SetActive (true);
			desctext.text = "Parang Salawaku adalah sepasang senjata tradisional dari Maluku. Parang Salawaku terdiri dari Parang (pisau panjang) dan Salawaku (perisai) yang pada masa lalu adalah senjata yang digunakan untuk berperang. Di lambang pemerintah kota Ambon, dapat dijumpai pula Parang Salawaku. Bagi masyarakat Maluku, Parang dan Salawaku adalah simbol kemerdekan rakyat. Senjata ini dapat disaksikan pada saat menari Cakalele, yaitu tarian yang menyimbolkan kekuatan kaum pria Maluku. Parang di tangan kanan penari melambangkan keberanian sementara salawaku di tangan kiri melambangkan perjuangan untuk mendapatkan keadilan.";
	}

	public void deschonai () {
			desc.gameObject.SetActive (true);
			desctext.text = "Rumah Honai terbuat dari kayu dengan atap berbentuk kerucut yang terbuat dari jerami atau ilalang. Honai sengaja dibangun sempit atau kecil dan tidak berjendela yang bertujuan untuk menahan hawa dingin pegunungan Papua. Honai biasanya dibangun setinggi 2,5 meter dan pada bagian tengah rumah disiapkan tempat untuk membuat api unggun untuk menghangatkan diri. Rumah Honai terbagi dalam tiga tipe, yaitu untuk kaum laki-laki (disebut Honai), wanita (disebut Ebei), dan kandang babi (disebut Wamai).";
	}

	public void descbaileo () {
			desc.gameObject.SetActive (true);
			desctext.text = "Rumah Baileo adalah rumah adat Maluku. Rumah Baileo merupakan representasi kebudayaan Maluku dan memiliki fungsi yang sangat penting bagi kehidupan masyarakat. Rumah Baileo adalah identitas setiap negeri di Maluku selain Masjid atau Gereja. Baileo berfungsi sebagai tempat penyimpanan benda-benda suci, tempat upacara adat, sekaligus sebagai balai warga. Ciri utama rumah Baileo adalah ukurannya besar, dan memiliki bentuk yang berbeda jika dibandingkan dengan rumah-rumah lain di sekitarnya.";
	}

	public void descewer () {
			desc.gameObject.SetActive (true);
			desctext.text = "Pakaian ini murni terbuat dari bahan alami yaitu jerami yang dikeringkan. Pakaian adat wanita Papua berupa rok dan baju kurung. Rok tersebut hanya digunakan sebagai bawahan untuk kaum wanita yang terbuat dari jerami atau serat kering tumbuh-tumbuhan, dan kemudian dirangkai menggunakan tali di bagian atasnya. Pakaian adat Ewer untuk pria terbuat dari kain beludru dengan model yang lebih sopan yang berupa Celana pendek sebatas lutut lengkap dengan kain penutup yang menjuntai di bagian depan yang digunakan sebagai bawahan.";
	}

	public void desccele () {
			desc.gameObject.SetActive (true);
			desctext.text = "Pakaian adat daerah Maluku ini memiliki nilai filosofis dan estetis yang tinggi. Selain itu, pakaian adat ini juga sudah menjadi ciri khas provinsi Maluku dan mewakili suku-suku lainnya yang tinggal di sana. Salah satu ciri khas dari baju cele adalah warnanya yang merah terang dengan motif bergaris perak ataupun emas yang geometris. Baju ini juga terbuat dari bahan kain yang tebal tapi masih nyaman ketika dipakai.";
	}

	public void desctifa () {
			desc.gameObject.SetActive (true);
			desctext.text = "Tifa mirip dengan alat musik gendang yang dimainkan dengan cara dipukul. Alat musik ini terbuat dari sebatang kayu yang dikosongi atau dihilangi isinya dan pada salah satu sisi ujungnya ditutupi, dan biasanya penutupnya digunakan kulit rusa yang telah dikeringkan untuk menghasilkan suara yang bagus dan indah. Bentuknyapun biasanya dibuat dengan ukiran. Setiap suku di Maluku dan Papua memiliki tifa dengan ciri khasnya masing-masing.";
	}

	public void descarababu () {
			desc.gameObject.SetActive (true);
			desctext.text = "Arababu adalah rebab tradisional khas Maluku yang terbuat dari bahan-bahan alam yang sangat sederhana. Instrumen ini sama seperti rebab pada umumnya, yaitu digesek menggunakan alat khusus. Arbabu dibuat dari tempurung kelapa, kulit hewan, kayu, sementara dawainya dibuat dari serat pohon pisang.";
	}

	public void descpasatimpo () {
			desc.gameObject.SetActive (true);
			desctext.text = "Pasatimpo adalah salah satu jenis parang yang biasanya digunakan oleh masyarakat Sulawesi Tengah dalam ritual pengobatan atau pengusiran roh halus. Dalam perkembangannya, senjata tradisional ini hanya digunakan dalam tari-tarian tradisional untuk menghargai para pahlawan di masa lampau. Selain dari itu, pasatimpo ini digunakan untuk keperluan dan aktivitas sehari-hari seperti memotong hewan untuk dimakan, mencari kayu bakar dan sebagainya.";
	}

	public void desctalawang () {
			desc.gameObject.SetActive (true);
			desctext.text = "Talawang adalah tameng atau perisai Suku Dayak yang terbuat dari kayu ulin atau kayu besi. Talawang berbentuk persegi panjang yang dibuat runcing pada bagian atas dan bawahnya. Panjang talawang sekitar 1 sampai dengan 2 meter dengan lebar maksimal 50 centimeter. Pada awalnya talawang lebih difungsikan sebagai pelengkap alat pertahanan diri ketika berperang, namun kemudian dalam perkembangan zaman talawang juga digunakan sebagai pelengkap dalam tari-tarian.";
	}

	public void desctambi () {
			desc.gameObject.SetActive (true);
			desctext.text = "Rumah adat tambi memiliki arsitektur bangunan yang unik dimana dinding rumah sekaligus juga berfungsi sebagai atap. Karena kerangka bagian atas rumah (tiang bumbungan dan kaso kaso) hanya menumpang diatas balok bundar yang tersusun sebagai belandar sekaligus berfungsi sebagai pondasi dan tiang. Pada prinsipnya rumah adat tambi adalah rumah bagi raja, para bangsawan maupun rakyat biasa. Yang membedakan rumah adat bsngsawan dan rumah adat yang dihuni oleh masyarakat biasa adalah terletak pada bentuk bumbungan rumah.";
	}
	
	public void descpanjang () {
			desc.gameObject.SetActive (true);
			desctext.text = "Rumah Panjang dari Kalimantan Barat terbuat dari kayu. Rumah panjang dari Kalimantan Barat mempunyai tinggi 5 sampai 8 meter. Tinggi rumah tergantung dari tinggi tiang yang menopang rumah tersebut. Rumah panjang dari Kalimantan barat mempunyai panjang sekitar 180 meter dan lebar 6 meter. Rumah panjang memiliki sekitar 50 ruangan. Ruangan-ruangan ini umumnya dihuni oleh banyak keluarga yang di dalamnya juga termasuk keluarga inti.";
	}

	public void descnggembe () {
			desc.gameObject.SetActive (true);
			desctext.text = "Baju Koje adalah atasan berupa kemeja dengan kerah tegak, dengan lengan yang panjang. Baju Koje dipakai dengan Puruka Pajana yaitu celana lebar yang dilengkapi dengan sarung di pinggang pemakainya. Baju Nggembe adalah baju adat khusus wanita atau remaja putri yang dikenakan saat pesta atau upacara adat. Baju ini memiliki bentuk yang unik, yakni segi empat dengan kerah bulat dan blus longgar yang panjang sampai ke pinggang.";
	}

	public void descngbaba () {
			desc.gameObject.SetActive (true);
			desctext.text = "Pakaian adat Kalimantan Barat untuk Laki-laki bernama King Baba. Dalam bahasa Dayak, King berarti pakaian dan Baba berarti laki-laki. Pakaian ini terbuat dari bahan kulit kayu tanaman ampuro atau kayu kapuo. Sama seperti pakaian laki-laki, pakaian adat Kalimantan Barat untuk para perempuan juga dibuat dari bahan dan cara yang sama. Namun, desainnya lebih sopan dengan perlengkapan antara lain penutup dada, stagen, kain bawahan, serta berbagai pernik lain seperti kalung, manik-manik, dan hiasan bulu burung enggang di kepalanya. ";
	}

	public void desckakula () {
			desc.gameObject.SetActive (true);
			desctext.text = "Kakula secara khusus adalah nama jenis alat musik yang terdiri atas tujuh buah gong kecil yang ditempatkan secara berderet. Nada yang terdapat pada Kakula yang terbuat dari kuningan atau tembaga memiliki kemiripan dengan nada yang ada pada Gamba-gamba atau Kakula kayu. ";
	}

	public void descsape () {
			desc.gameObject.SetActive (true);
			desctext.text = "Sape menurut orang Dayak merupakan alat musik ini berfungsi untuk menyatakan perasaan, baik perasaan riang gembira, rasa sayang, kerinduan, bahkan rasa duka nestapa. Pada zaman Dahulu, memainkan alat musik pada siang hari, umumnya irama yang dihasilkan sape menyatakan perasaan gembira dan suka-ria. Sedangkan jika sape dimainkan pada malam hari biasanya akan menghasilkan irama yang bernada sendu, syahdu, atau sedih.";
	}

	public void ButtonRA () {
			botaoanim.SetTrigger("RA");
			status = 1;
			hal = 0;
	}
	
	public void ButtonST () {
			botaoanim.SetTrigger("ST");
			status = 0;
			hal = 0;
	}
	
	public void ButtonPA () {
			botaoanim.SetTrigger("PA");
			status = 2;
			hal = 0;
	}

	public void ButtonAM () {
			botaoanim.SetTrigger("AM");
			status = 3;
			hal = 0;
	}

	public void Selanjutnya() {
			hal++;
	}
	
	public void Kembali() {
			hal--;
	}
}
}
