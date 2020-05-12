create database danhGiaDoanVien
go

use danhGiaDoanVien
go

create table nam
(
	id varchar(10) primary key,
	ten nvarchar(100) not null -- dùng để hiển thị lên giao diện
)
go

create table ChiDoan
(
	id varchar(10) primary key,
	ten nvarchar(100) not null,
	soThanhVien int not null default 0,
	tongSV int not null default 0,
	tongNuSV int not null default 0,
	tongGV int not null default 0,
	tongNuGV int not null default 0
)
go

create table KetQuaChiDoan
(
	id int identity(1,1) primary key,
	idChiDoan varchar(10) references ChiDoan(id) on delete cascade on update cascade,
	idNamHoc varchar(10) references Nam(id) on delete cascade on update cascade,
	xepLoai nvarchar(100),
	xuatSac int not null default 0,
	kha int not null default 0,
	trungBinh int not null default 0,
	yeuKem int not null default 0,
	soThanhVien int not null default 0,
	tongSV int not null default 0,
	tongGV int not null default 0,
	tongNuSV int not null default 0,
	tongNuGV int not null default 0,
	tongDVUT int not null default 0,
	daXong bit not null default 0,
	ghiChu nvarchar(1000)
)
go

create table SinhVien
(
	MSSV varchar(10) primary key,
	ten nvarchar(100) not null,
	gioiTinh nvarchar(3) not null default 'Nam',
	chiDoan varchar(10) references ChiDoan(id) on delete set null on update cascade,
	doanVien bit not null default 0 -- 0 là chưa phải đoàn viên, 1 = đã là đoàn viên
)
go

create table KetQuaSinhVien
(
	id int identity(1,1) primary key,
	idKetQuaChiDoan int references KetQuaChiDoan(id) on delete cascade,
	MSSV varchar(10) references SinhVien(MSSV) on delete cascade,
	diemHK1 float,
	diemHK2 float,
	tongHK float,
	DRLHK1 int,
	DRLHK2 int,
	DRL int,
	xepLoai nvarchar(100),
	thanhTichTieuBieu nvarchar(200),
	doanVienUuTu bit not null default 0, -- 0 false 1 true
	ghiChu nvarchar(1000)
)
go

create table GiangVien
(
	MSGV varchar(10) primary key,
	ten nvarchar(100) not null,
	gioiTinh nvarchar(3) not null default 'Nam',
	chiDoan varchar(10) references ChiDoan(id) on delete set null on update cascade,
	doanVien bit not null default 0 -- 0 false 1 true
)
go

create table KetQuaGiangVien
(
	id int identity(1,1) primary key,
	idKetQuaChiDoan int references KetQuaChiDoan(id) on delete cascade,
	MSGV varchar(10) references GiangVien(MSGV) on delete cascade,
	ketQuaDanhGia nvarchar(100),
	xepLoai nvarchar(20),
	thanhTichTieuBieu nvarchar(200),
	doanVienUuTu bit not null default 0, -- 0 false 1 true
	ghiChu nvarchar(1000)
)
go

create table TaiKhoan
(
	taiKhoan varchar(100) primary key,
	matKhau varchar(32) not null,
	MSGV varchar(10) references GiangVien(MSGV) on delete cascade,
	loaiTaiKhoan nvarchar(10) not null default N'giảng viên'
)
go

create table DoanVienUuTuSV
(
	id int identity(1,1) primary key,
	MSSV varchar(10) references SinhVien(MSSV) on delete cascade not null,
	idKetQuaChiDoan int references KetQuaChiDoan(id) on delete cascade not null,
	phieuBau int not null default 0,
	tongPhieu int not null default 0,
)
go

create table DoanVienUuTuGV
(
	id int identity(1,1) primary key,
	MSGV varchar(10) references GiangVien(MSGV) on delete cascade not null,
	idKetQuaChiDoan int references KetQuaChiDoan(id) on delete cascade not null,
	phieuBau int not null default 0,
	tongPhieu int not null default 0,
)
go

-----------------------------TaiKhoan------------------------------------

create proc  USP_Login --V
@user varchar(100), @password varchar(32)
as
begin
	select * from taiKhoan where taiKhoan = @user and matKhau = @password
end
go

-----------------------------Nam------------------------------------

create proc USP_AddSemester -- V
@idSemester varchar(10), @name nvarchar(100)
as
begin
	insert into nam(id, ten)
	values (@idSemester, @name)
end
go

create proc USP_UpdateSemester -- V
@idSemester varchar(10), @name nvarchar(100)
as
begin
	update nam set ten = @name
	where id = @idSemester
end
go

create proc USP_DeleteSemester -- V
@idSemester varchar(10)
as
begin
	delete nam
	where id = @idSemester
end
go

-----------------------------ChiDoan------------------------------------

create proc USP_GetListGroup -- V
as
begin
	select * from ChiDoan
end
go

create proc USP_AddGroup -- v
@idGroup varchar(10), @name nvarchar(100)
as
begin
	insert into ChiDoan(id, ten)
	values (@idGroup, @name)
end
go

create proc USP_UpdateGroup
@idGroup varchar(10), @name nvarchar(100)
as
begin
	update ChiDoan set ten = @name
	where id = @idGroup
end
go

create proc USP_DeleteGroup
@idGroup varchar(10)
as
begin
	delete ChiDoan
	where id = @idGroup
end
go

create proc USP_PlusMember
@idGroup varchar(10), @amount int
as
begin
	update ChiDoan set soThanhVien += @amount
	where id = @idGroup
end
go

create proc USP_MinusMember
@idGroup varchar(10), @amount int
as
begin
	declare @soThanhVien int = (select soThanhVien from ChiDoan where id = @idGroup)
	if @soThanhVien >= @amount
	begin
		update ChiDoan set soThanhVien -= @amount
		where id = @idGroup
	end
end
go

create proc USP_PlusTeacher
@idGroup varchar(10), @amount int
as
begin
	update ChiDoan set tongGV += @amount
	where id = @idGroup
	exec USP_PlusMember @idGroup, @amount
end
go

create proc USP_MinusTeacher
@idGroup varchar(10), @amount int
as
begin
	declare @tongGV int = (select tongGV from ChiDoan where id = @idGroup)
	if @tongGv >= @amount
	begin
		update ChiDoan set tongGV -= @amount
		where id = @idGroup
		exec USP_MinusMember @idGroup, @amount
	end
end
go

create proc USP_PlusStudent
@idGroup varchar(10), @amount int
as
begin
	update ChiDoan set tongSV += @amount
	where id = @idGroup
	exec USP_PlusMember @idGroup, @amount
end
go

create proc USP_MinusStudent
@idGroup varchar(10), @amount int
as
begin
	declare @tongSV int = (select tongSV from ChiDoan where id = @idGroup)
	if @tongSv >= @amount
	begin
		update ChiDoan set tongSV -= @amount
		where id = @idGroup
		exec USP_MinusMember @idGroup, @amount
	end
end
go



-----------------------------SinhVien------------------------------------

create proc USP_GetListStudent
as
begin
	select * from SinhVien
end
go

create proc USP_AddStudent
@idStudent varchar(10), @name nvarchar(100), @sex nvarchar(3), @group varchar(10), @isMember bit
as
begin
	insert into SinhVien
	values (@idStudent, @name, @sex, @group, @isMember)
	update ChiDoan set tongSV = tongSV + 1, soThanhVien += 1
	where id = @group
	if @sex = N'Nữ'
		begin
			update ChiDoan set tongNuSV += 1
			where id = @group
		end
end
go

create proc USP_UpdateStudent
@idStudent varchar(10), @name nvarchar(100), @sex nvarchar(3), @group varchar(10), @isMember bit
as
begin
	select * into #tempTable from SinhVien where MSSV = @idStudent
	declare @oldGroup varchar(10) = (select chiDoan from #tempTable)
	declare @oldSex nvarchar(3) = (select gioiTinh from #tempTable)
	update SinhVien set ten = @name, gioiTinh = @sex, chiDoan = @group, doanVien = @isMember
	where MSSV = @idStudent
	if @oldGroup != @group
	begin
		--Group cu tru 1 sinh viên
		exec USP_MinusStudent @oldgroup, 1
		if @oldSex = N'Nữ'
		begin
			update ChiDoan set tongNuSV -= 1
			where id = @oldGroup
		end
		--Group moi them 1 sinh viên
		exec USP_PlusStudent @group, 1
		if @sex = N'Nữ'
		begin
			update ChiDoan set tongNuSV += 1
			where id = @group
		end	
	end
	else
	begin
		if @sex = N'Nữ' and @oldSex = 'Nam'
		begin
			update ChiDoan set tongNuSV += 1
			where id = @group
		end	
		else if @sex = N'Nam' and @oldSex = N'Nữ'
		begin
			update ChiDoan set tongNuSV -= 1
			where id = @group
		end	
	end
end
go

create proc USP_DeleteStudent
@idStudent varchar(10)
as
begin
	select * into #tempTable from SinhVien where MSSV = @idStudent
	declare @sex nvarchar(3) = (select gioiTinh from #tempTable)
	declare @group nvarchar(3) = (select chiDoan from #tempTable)
	delete from SinhVien
	where MSSV = @idStudent	
	update ChiDoan set tongGV = tongGV - 1, soThanhVien -= 1
	where id = (select chiDoan from SinhVien where MSSV = @idStudent)
	if @sex = N'Nữ'
		begin
			update ChiDoan set tongNuSV -= 1
			where id = @group
		end
end
go

create trigger UTG_DeleteStudent
on SinhVien after delete
as
begin
	declare @idMember varchar(10) = (select MSSV from deleted)
	declare @idGroup varchar(10) = (select chiDoan from deleted)
	declare @sex nvarchar(3) = (select gioiTinh from deleted)
	update ChiDoan set soThanhVien -= 1, tongSV -= 1
	where id = @idGroup
	if @sex = N'Nữ'
	begin
		update ChiDoan set tongNuSV -= 1
	where id = @idGroup
	end
end
go

-----------------------------GiangVien------------------------------------

create proc USP_GetListTeacher
as
begin
	select * from GiangVien
end
go

create proc USP_AddTeacher
@idTeacher varchar(10), @name nvarchar(100), @sex nvarchar(3), @group varchar(10), @isMember bit
as
begin
	insert into GiangVien
	values (@idTeacher, @name, @sex, @group, @isMember)
	update ChiDoan set tongGV = tongGV + 1, soThanhVien += 1
	where id = @group
	if @sex = N'Nữ'
		begin
			update ChiDoan set tongNuGV += 1
			where id = @group
		end
end
go

create proc USP_UpdateTeacher
@idTeacher varchar(10), @name nvarchar(100), @sex nvarchar(3), @group varchar(10), @isMember bit
as
begin
	select * into #tempTable from GiangVien where MSGV = @idTeacher
	declare @oldGroup varchar(10) = (select chiDoan from #tempTable)
	declare @oldSex nvarchar(3) = (select gioiTinh from #tempTable)
	update GiangVien set ten = @name, gioiTinh = @sex, chiDoan = @group, doanVien = @isMember
	where MSGV = @idTeacher
	if @oldGroup != @group
	begin
		--Group cu tru 1 giang vien
		exec USP_MinusTeacher @oldgroup, 1
		if @oldSex = N'Nữ'
		begin
			update ChiDoan set tongNuGV -= 1
			where id = @oldGroup
		end
		--Group moi them 1 giang vien
		exec USP_PlusTeacher @group, 1
		if @sex = N'Nữ'
		begin
			update ChiDoan set tongNuGV += 1
			where id = @group
		end
	end
	else
	begin
		if @sex = N'Nữ' and @oldSex = N'Nam'
		begin
			update ChiDoan set tongNuGV += 1
			where id = @oldGroup
		end
		else if @sex = N'Nam' and @oldSex = N'Nữ'
		begin
			update ChiDoan set tongNuGV -= 1
			where id = @oldGroup
		end
	end
end
go

create proc USP_DeleteTeacher
@idTeacher varchar(10)
as
begin
	select * into #tempTable from GiangVien where MSGV = @idTeacher
	declare @sex nvarchar(3) = (select gioiTinh from #tempTable)
	declare @group nvarchar(3) = (select chiDoan from #tempTable)
	delete from GiangVien
	where MSGV = @idTeacher	
	update ChiDoan set tongGV = tongGV - 1, soThanhVien -= 1
	where id = (select chiDoan from GiangVien where MSGV = @idTeacher)
	if @sex = N'Nữ'
		begin
			update ChiDoan set tongNuSV -= 1
			where id = @group
		end
end
go

create trigger UTG_DeleteTeacher
on GiangVien after delete
as
begin
	declare @idMember varchar(10) = (select MSGV from deleted)
	declare @idGroup varchar(10) = (select chiDoan from deleted)
	declare @sex nvarchar(3) = (select gioiTinh from deleted)
	update ChiDoan set soThanhVien -= 1, tongGV -= 1
	where id = @idGroup
	if @sex = N'Nữ'
	begin
		update ChiDoan set tongNuGV -= 1
	where id = @idGroup
	end
end
go

-----------------------------DVUTSV------------------------------------

create proc USP_GetListGoodStudent
as
begin
	select * from DoanVienUuTuSV
end
go

create proc USP_AddGoodStudent
@idStudent varchar(10), @idScoresGroup int, @voteFor int, @totalVote int
as
begin
	insert into DoanVienUuTuSV
	values (@idStudent, @idScoresGroup, @voteFor, @totalVote)
end
go

create proc USP_UpdateGoodStudent
@id int, @voteFor int, @totalVote int
as
begin
	update DoanVienUuTuSV set phieuBau = @voteFor, tongPhieu = @totalVote
	where id = @id
end
go

create proc USP_DeleteGoodStudent
@id int
as
begin
	delete DoanVienUuTuSV where id = @id
end
go

create trigger UTG_AddGoodStudent
on DoanVienUuTuSV after insert
as
begin
	update KetQuaChiDoan set tongDVUT += 1
	where id = (select idKetQuaChiDoan from inserted)
end
go

create trigger UTG_DeleteGoodStudent
on DoanVienUuTuSV after delete
as
begin
	declare @id int = (select top(1) idKetQuaChiDoan from deleted)
	declare @count int = (select count(*) from KetQuaChiDoan where id = @id)
	if @count = 1
	begin
		update KetQuaChiDoan set tongDVUT -= 1
		where id = (select idKetQuaChiDoan from deleted)
	end
end
go

-----------------------------DVUTGV------------------------------------

create proc USP_GetListGoodTeacher
as
begin
	select * from DoanVienUuTuGV
end
go

create proc USP_AddGoodTeacher
@idTeacher varchar(10), @idScoresGroup int, @voteFor int, @totalVote int
as
begin
	insert into DoanVienUuTuSV
	values (@idTeacher, @idScoresGroup, @voteFor, @totalVote)
end
go

create proc USP_UpdateGoodTeacher
@id int, @voteFor int, @totalVote int
as
begin
	update DoanVienUuTuGV set phieuBau = @voteFor, tongPhieu = @totalVote
	where id = @id
end
go

create proc USP_DeleteGoodTeacher
@id int
as
begin
	delete DoanVienUuTuGV where id = @id
end
go

create trigger UTG_AddGoodTeacher
on DoanVienUuTuGV after insert
as
begin
	update KetQuaChiDoan set tongDVUT += 1
	where id = (select idKetQuaChiDoan from inserted)
end
go

create trigger UTG_DeleteGoodTeacher
on DoanVienUuTuGV after delete
as
begin
	declare @id int = (select top(1) idKetQuaChiDoan from deleted)
	declare @count int = (select count(*) from KetQuaChiDoan where id = @id)
	if @count = 1
	begin
		update KetQuaChiDoan set tongDVUT -= 1
		where id = (select idKetQuaChiDoan from deleted)
	end
end
go

-----------------------------KetQuaGiangVien------------------------------------

create proc USP_GetScoresTeacher
as
begin
	select * from KetQuaGiangVien
end
go

create proc USP_GetListScoresTeacher
as
begin
	select * from KetQuaGiangVien
end
go


create proc USP_AddScoresTeacher
@idTeacher varchar(10), @idScoresGroup int
as
begin
	insert into KetQuaGiangVien (MSGV, idKetQuaChiDoan)
	values (@idTeacher, @idScoresGroup)
end
go

create proc USP_UpdateScoresTeacher
@id varchar(10), @evaluation nvarchar(100), @rank nvarchar(20), @achievement nvarchar(200), @isGoodTeacher bit, @note nvarchar(1000)
as
begin
	update KetQuaGiangVien
		set [ketQuaDanhGia] = @evaluation, [xepLoai] = @rank, [thanhTichTieuBieu] = @achievement, [doanVienUuTu] = @isGoodTeacher, [ghiChu] = @note
	where id = @id
end
go

create proc USP_SetGoodTeacher
@id int, @voteFor int, @totalVote int
as
begin
	update KetQuaGiangVien 
		set doanVienUuTu = 1
	where [id] = @id
	select * into #tempTable from KetQuaGiangVien where id = @id
	declare @idTeacher int = (select MSGV from #tempTable)
	declare @idScoresGroup int = (select idKetQuaChiDoan from #tempTable)
	exec USP_AddGoodTeacher @idTeacher, @idScoresGroup, @voteFor, @totalVote
end
go

create proc USP_SetNormalTeacher
@id int
as
begin
	update KetQuaGiangVien set doanVienUuTu = 0
	where id = @id
	select * into #tempTable from KetQuaGiangVien where id = @id
	declare @idTeacher varchar(10) = (select MSGV from #tempTable)
	declare @idScoresGroup int = (select idKetQuaChiDoan from #tempTable)
	declare @idGoodTeacher int = (select id from DoanVienUuTuGV where MSGV = @idTeacher and idKetQuaChiDoan = @idScoresGroup)
	exec USP_DeleteGoodStudent @idGoodTeacher
end
go

create trigger UTG_InsertUpdateScoresTeacher
on KetQuaGiangVien for update
as
begin
	declare @id int = (select id from inserted)
	declare @oldRank varchar(20) = (select xepLoai from KetQuaGiangVien where id = @id)
	declare @rank nvarchar(20) = (select xepLoai from inserted)
	declare @idScoresGroup int = (select idKetQuaChiDoan from inserted)
	
	if @oldRank != null
	begin
		if @oldRank = N'Xuất sắc'
		begin
			update KetQuaChiDoan set xuatSac -= 1
			where id = @idScoresGroup
		end
		else if @oldRank = N'Khá'
		begin
			update KetQuaChiDoan set kha -= 1
			where id = @idScoresGroup
		end
		else if @oldRank = N'Trung bình'
		begin
			update KetQuaChiDoan set trungBinh -= 1
			where id = @idScoresGroup
		end
		else if @oldRank = N'Yếu kém'
		begin
			update KetQuaChiDoan set yeuKem -= 1
			where id = @idScoresGroup
		end
	end

	if @rank != null
	begin
		if @rank = N'Xuất sắc'
		begin
			update KetQuaChiDoan set xuatSac += 1
			where id = @idScoresGroup
		end
		else if @rank = N'Khá'
		begin
			update KetQuaChiDoan set kha += 1
			where id = @idScoresGroup
		end
		else if @rank = N'Trung bình'
		begin
			update KetQuaChiDoan set trungBinh += 1
			where id = @idScoresGroup
		end
		else if @rank = N'Yếu kém'
		begin
			update KetQuaChiDoan set yeuKem += 1
			where id = @idScoresGroup
		end
	end
end
go

-----------------------------KetQuaSinhVien------------------------------------

create proc USP_GetScoresStudent
as
begin
	select * from KetQuaSinhVien
end
go

create proc USP_AddScoresStudent
@idStudent varchar(10), @idScoresGroup int
as
begin
	insert into KetQuaSinhVien (MSSV, idKetQuaChiDoan)
	values (@idStudent, @idScoresGroup)
end
go

create proc USP_UpdateScoresStudent --Thủ công
@id int, @scoresSemester1 float, @scoresSemester2 float, @scoresTrain1 int, @scoresTrain2 int, @rank nvarchar(100), @achievements nvarchar(200), @note nvarchar(1000), @isGoodMember bit
as
begin
	declare @scoresSemester float, @scoresTrain int
	set @scoresSemester = (@scoresSemester1 + @scoresSemester2) / 2
	set @scoresTrain = (@scoresTrain1 + @scoresTrain2) / 2
	update KetQuaSinhVien 
		set diemHK1 = @scoresSemester1, [diemHK2] = @scoresSemester2, [tongHK] = @scoresSemester, [DRLHK1] = @scoresTrain1, [DRLHK2] = @scoresTrain2, [DRL] = @scoresTrain, [xepLoai] = @rank,
			[thanhTichTieuBieu] = @achievements, [ghiChu] = @note, doanVienUuTu = @isGoodMember
	where [id] = @id
end
go

create proc USP_UpdateScoresStudentNotYet --Học lưng chừng, chưa học xong hết năm
@id int, @scoresSemester1 float, @scoresTrain1 int
as
begin
	update KetQuaSinhVien 
		set diemHK1 = @scoresSemester1, [DRLHK1] = @scoresTrain1
	where [id] = @id
end
go

create proc USP_UpdateScoresStudentAuto -- Xếp hạng chạy tự động
@id int, @scoresSemester1 float, @scoresSemester2 float, @scoresTrain1 int, @scoresTrain2 int, @achievements nvarchar(200), @note nvarchar(1000)
as
begin
	declare @scoresSemester float, @scoresTrain int
	set @scoresSemester = (@scoresSemester1 + @scoresSemester2) / 2
	set @scoresTrain = (@scoresTrain1 + @scoresTrain2) / 2
	update KetQuaSinhVien 
		set diemHK1 = @scoresSemester1, [diemHK2] = @scoresSemester2, [tongHK] = @scoresSemester, [DRLHK1] = @scoresTrain1, [DRLHK2] = @scoresTrain2, [DRL] = @scoresTrain,
			[thanhTichTieuBieu] = @achievements,[ghiChu] = @note
	where [id] = @id
end
go

create proc USP_SetGoodStudent
@id int, @voteFor int, @totalVote int
as
begin
	update KetQuaSinhVien 
		set doanVienUuTu = 1
	where [id] = @id
	select * into #tempTable from KetQuaSinhVien where id = @id
	declare @idStudent int = (select MSSV from #tempTable)
	declare @idScoresGroup int = (select idKetQuaChiDoan from #tempTable)
	exec USP_AddGoodStudent @idStudent, @idScoresGroup, @voteFor, @totalVote
end
go

create proc USP_SetNormalStudent
@id int
as
begin
	update KetQuaSinhVien set doanVienUuTu = 0
	where id = @id
	select * into #tempTable from KetQuaSinhVien where id = @id
	declare @idStudent varchar(10) = (select MSSV from #tempTable)
	declare @idScoresGroup int = (select idKetQuaChiDoan from #tempTable)
	declare @idGoodStudent int = (select id from DoanVienUuTuSV where MSSV = @idStudent and idKetQuaChiDoan = @idScoresGroup)
	exec USP_DeleteGoodStudent @idGoodStudent
end
go

-----------------------------KetQuaChiDoan------------------------------------

create proc USP_GetScoresGroup
as
begin
	select * from KetQuaChiDoan
end
go

create proc USP_AddScoresGroup
@idGroup varchar(10), @idSemester varchar(10)
as
begin
	select * into #tempTable from ChiDoan where id = @idGroup
	declare @tongSV int, @tongGV int, @tongThanhVien int, @tongNuSV int, @tongNuGV int

	set @tongSV = (select tongSV from #tempTable)
	set @tongGV = (select tongGV from #tempTable)
	set @tongNuSV = (select tongNuSV from #tempTable)
	set @tongNuGV = (select tongNuGV from #tempTable)
	set @tongThanhVien = @tongSV + @tongGV

	-- Thêm dữ liệu vào
	insert into KetQuaChiDoan(idChiDoan, idNamHoc, soThanhVien, tongSV, tongNuSV, tongGV, tongNuGV)
	values (@idGroup, @idSemester, @tongThanhVien, @tongSV, @tongNuSV, @tongGV, @tongNuGV)
end
go

create proc USP_UpdateScoresGroup
@id int, @rank nvarchar(100), @note nvarchar(1000)
as
begin
	update KetQuaChiDoan set ghiChu = @note, xepLoai = @rank
	where id = @id
end
go

create proc USP_UpdateScoresGroup2
@id int, @idSemester varchar(10), @rank nvarchar(100), @note nvarchar(1000)
as
begin
	update KetQuaChiDoan set ghiChu = @note, xepLoai = @rank, idNamHoc = @idSemester
	where id = @id
end
go

create proc USP_DeleteScoresGroup
@id int
as
begin
	delete KetQuaChiDoan
	where id = @id
end
go

create trigger UTG_InsertSrocesGroup --Nếu đã tồn tại kết quả chi đoàn này rồi thì hủy
on KetQuaChiDoan for insert
as
begin
	declare @idGroup varchar(10) = (select idChiDoan from inserted)
	declare @idSemester varchar(10) = (select idNamHoc from inserted)
	declare @count int = (select count(*) from KetQuaChiDoan where idNamHoc = @idSemester and idChiDoan = @idGroup)

	if @count > 1
	begin
		rollback tran
	end
end
go

----------------------------------------------------------------------------------------------------------------
