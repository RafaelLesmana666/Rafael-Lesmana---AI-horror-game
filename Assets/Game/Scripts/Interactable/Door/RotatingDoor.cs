using System.Collections;
using UnityEngine;

public class RotatingDoor : Door
{
    [SerializeField]
    private float _openAngle;

    [SerializeField]
    private float _closeAngle;

    public override void Open()
    {
        // Kode untuk melakukan sesuatu sebelum pintu terbuka

        if (_animatingDoorCoroutine != null)
        {
            StopCoroutine(_animatingDoorCoroutine);
        }

        _animatingDoorCoroutine = StartCoroutine(RotateDoor(_openAngle));

        // Memanggil function Open dari class base/parent (Door)
        // Sehingga kode di dalam function Open yang ada di parent
        // akan tetap dijalankan
        base.Open();
    }

    public override void Close()
    {
        // Kode untuk melakukan sesuatu sebelum pintu tertutup
        if (_animatingDoorCoroutine != null)
        {
            StopCoroutine(_animatingDoorCoroutine);
        }

        _animatingDoorCoroutine = StartCoroutine(RotateDoor(_closeAngle));

        // Memanggil function Close dari class base/parent (Door)
        // Sehingga kode di dalam function Close yang ada di parent
        // akan tetap dijalankan
        base.Close();
    }

    //menggunakan coroutine buat animasi
    private IEnumerator RotateDoor(float targetAngle)
    {
        // Mengubah status bahwa animasi memutar pintu sedang berjalan
        _isAnimating = true;
        // Menentukan sudut awal => rotasi pintu saat ini di sumbu y
        float startAngle = _doorTransform.localEulerAngles.y;
        // Menyediakan variable untuk menghitung waktu animasi yang sedang berjalan
        float time = 0;

        // Melakukan proses pengulangan (animasi)
        // selama waktu animasi kurang dari durasi animasi
        while (time < _duration)
        {
            // Menambahkan time dengan satu setiap detik
            time = time + Time.deltaTime;
            // Melakukan interpolasi sudut awal ke sudut target
            // Menentukan alpha dengan rumus time/duration
            // alpha bernilai 0 s.d 1, alpha merupakan nilai yang dianimasikan
            // 0 => sudut rotasi awal, 1 => sudut rotasi akhir
            float angle = Mathf.LerpAngle(startAngle, targetAngle, time / _duration);
            // Mengubah rotasi sumbu Y pintu dengan sudut yang sudah dihitung
            _doorTransform.localRotation = Quaternion.Euler(0f, angle, 0f);
            // Animasi dijalankan setiap frame
            yield return null;
        }
        // Setelah animasi selesai, memastika rotasi pintu di sumbu Y
        // mencapai sudut target
        _doorTransform.localRotation = Quaternion.Euler(0f, targetAngle, 0);
        // Mengubah status bahwa animasi memutar pintu sudah selesai
        _isAnimating = false;
    }
}
