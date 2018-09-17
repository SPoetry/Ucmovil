<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class PedidoTemporal extends Model
{
    protected $table = 'pedidos_temporales';
    protected $fillable = ['user_id','producto_id', 'cantidad'];

    public function usuario()
    {
      return $this->belongsTo(User::class, 'user_id', 'id');
    }

    public function producto()
    {
      return $this->belongsTo(Inventario::class, 'producto_id', 'id_producto');
    }
}
