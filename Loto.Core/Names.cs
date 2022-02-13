﻿using Loto.Core.Generators;

namespace Loto.Core
{
	public class Names
	{
		private static string[] _commonNames = new[]
		{
			"Ninh",
			"Binh Minh",
			"Giang",
			"Luong",
			"Bao An",
			"Thien An",
			"Duy Khang",
			"Hau",
			"Bao Lam",
			"Thang",
			"Thai",
			"Hai Nam",
			"Lap",
			"Ngoc Huy",
			"Quyen",
			"Hien",
			"Thanh Son",
			"Khuong",
			"Tuan Anh",
			"Nhat Duy",
			"Thanh Phong",
			"Duc",
			"Hoang Nam",
			"Vuong",
			"Hoang Long",
			"Nhan",
			"Chi Bao",
			"Thien",
			"Dung",
			"Nhat Minh",
			"Anh Tuan",
			"Hoang Minh",
			"Quang Anh",
			"Kien",
			"Quoc Huy",
			"Quan",
			"Bao Nam",
			"Dang Khoi",
			"Nam",
			"Tri",
			"Trung Kien",
			"Tuan",
			"Tuan Kiet",
			"Nghia",
			"Vinh",
			"Thuyen",
			"Viet",
			"Luan",
			"Duong",
			"Thanh Tung",
			"Anh Khoi",
			"Hoang Hai",
			"Duy Khanh",
			"Bao Khanh",
			"Minh",
			"Hai Dang",
			"Hieu",
			"Hai Phong",
			"An",
			"Bach",
			"Minh Chau",
			"Anh",
			"Quy",
			"Dat",
			"Minh Dang",
			"Nghi",
			"The Anh",
			"Hoang Anh",
			"Hiep",
			"Du",
			"Phuc Hung",
			"Hoang",
			"Nguyen Khang",
			"Ngoc",
			"Minh Phuc",
			"Hai Anh",
			"Tung",
			"Lam",
			"Khang",
			"Gia Minh",
			"Nhat Linh",
			"Duy Long",
			"Danh",
			"Nhat",
			"Manh",
			"Minh Tuan",
			"Phi Long",
			"Dang Khoa",
			"Nguyen",
			"Tai",
			"Binh",
			"Chien",
			"Quoc Hung",
			"Quoc Khanh",
			"Quang",
			"Phuc Nguyen",
			"Hao",
			"Dieu",
			"Manh Hung",
			"Bao Thien",
			"Thien Phu",
			"Hung",
			"Minh Tam",
			"Phuong",
			"Quyet",
			"Cuong",
			"Thanh Hai",
			"Hoa",
			"Khoi Nguyen",
			"Gia Phuc",
			"Loc",
			"Thi",
			"Huan",
			"Minh Hai",
			"Khanh",
			"Linh",
			"Hoang Tung",
			"Minh Khang",
			"Trung Hieu",
			"Tan Phat",
			"Thach",
			"Duy Anh",
			"Hai",
			"Luc",
			"Quoc Anh",
			"Phuc Khang",
			"Bao",
			"Tu",
			"Han",
			"Thanh Binh",
			"Tan",
			"Huy Hoang",
			"Phuc",
			"Khiem",
			"Khoa",
			"Gia Huy",
			"Tien Dung",
			"Nghiem",
			"Hoang Phuc",
			"Truong",
			"Hoang Thien",
			"Thanh",
			"Long",
			"Phuc Lam",
			"Vu",
			"Bao Long",
			"Cong",
			"Dang",
			"Minh Thien",
			"Huong",
			"Thuan",
			"Tuan Khanh",
			"Gia Hung",
			"Nhat Anh",
			"Bao Minh",
			"Quang Vinh",
			"Hong Phuc",
			"Ben",
			"Minh Quan",
			"Anh Khoa",
			"Phung",
			"Thoai",
			"Khoi",
			"Duc Huy",
			"Hong Quan",
			"Viet Hoang",
			"Tuyen",
			"Tung Lam",
			"Duy",
			"Toan",
			"Yen",
			"Tien",
			"Thinh",
			"Minh Duc",
			"Nhat Huy",
			"The Vinh",
			"Tuan Vu",
			"Si",
			"Thanh Nhan",
			"Khai",
			"Minh Hieu",
			"Viet Anh",
			"Bin",
			"Trong Nhan",
			"Quynh",
			"Chung",
			"Minh Anh",
			"Gia Bao",
			"Huynh",
			"Minh Hoang",
			"Quang Huy",
			"Loi",
			"Minh Phuong",
			"Quang Nhat",
			"Khanh Duy",
			"Huy",
			"Son",
			"Gia Kiet",
			"Phat",
			"Nam Khanh",
			"Sang",
			"Nhat Hoang",
			"Trung",
			"Tam",
			//"Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia",
			//"Miller", "Davis", "Rodriguez", "Martinez", "Hernandez",
			//"Lopez", "Gonzales", "Wilson", "Anderson", "Thomas",
			//"Taylor", "Moore", "Jackson", "Martin", "Lee",
			//"Perez", "Thompson", "White", "Harris", "Sanchez",
			//"Clark", "Ramirez", "Lewis", "Robinson", "Walker",
			//"Young", "Allen", "King", "Wright", "Scott",
			//"Torres", "Nguyen", "Hill", "Flores", "Green",
			//"Adams", "Nelson", "Baker", "Hall", "Rivera",
			//"Campbell", "Mitchell", "Carter", "Roberts", "Gomez",
			//"Phillips", "Evans", "Turner", "Diaz", "Parker",
			//"Cruz", "Edwards", "Collins", "Reyes", "Stewart",
			//"Morris", "Morales", "Murphy", "Cook", "Rogers",
			//"Gutierrez", "Ortiz", "Morgan", "Cooper", "Peterson",
			//"Bailey", "Reed", "Kelly", "Howard", "Ramos",
			//"Kim", "Cox", "Ward", "Richardson", "Watson",
			//"Brooks", "Chavez", "Wood", "James", "Bennet",
			//"Gray", "Mendoza", "Ruiz", "Hughes", "Price",
			//"Alvarez", "Castillo", "Sanders", "Patel",
			//"Myers", "Long", "Ross", "Foster", "Jimenez"
		};

		public static string GetOne()
		{
			var idx = Randomizer.Next(_commonNames.Length);
			return _commonNames[idx];
		}

		public static string GetOne(int index)
		{
			index %= _commonNames.Length;
			return _commonNames[index];
		}
	}
}